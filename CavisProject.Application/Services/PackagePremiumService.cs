﻿using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.PackagePremiumViewModels;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Application.ViewModels.UserViewModels;
using CavisProject.Domain.Entity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Services
{
    public class PackagePremiumService : IPackagePremiumService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IValidator<CreatePackagePremiumViewModel> _validator;
        public PackagePremiumService(IValidator<CreatePackagePremiumViewModel> validator,UserManager<User> userManager,IUnitOfWork unitOfWork, IClaimsService claimsService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _claimsService = claimsService;
            _mapper = mapper;
            _userManager= userManager;
            _validator =validator;
        }
        public async Task<ApiResponse<Pagination<UserViewModel>>> GetPremiumUsersAsync(int pageIndex, int pageSize)
        {
            var response = new ApiResponse<Pagination<UserViewModel>>();
            try
            {
                var packageDetails = await _unitOfWork.PackageDetailRepository.GetAllAsync();
                var premiumUsers = packageDetails.Where(pd => pd.Status == 1).Select(pd => pd.UserId).ToList();

                var users = await _userManager.Users
                    .Where(u => premiumUsers.Contains(u.Id))
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var totalItemsCount = premiumUsers.Count;

                var userViewModels = new List<UserViewModel>();

                foreach (var user in users)
                {
                    var packageDetail = packageDetails.FirstOrDefault(pd => pd.UserId == user.Id);
                    var packagePremium = await _unitOfWork.PackagePremiumRepository.GetByIdAsync(packageDetail.PackagePremiumId.Value);

                    var userViewModel = _mapper.Map<UserViewModel>(user);
                 //   userViewModel.PackagePremiumId = packagePremium?.PackagePremiumName;

                    userViewModels.Add(userViewModel);
                }

                var pagination = new Pagination<UserViewModel>
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    TotalItemsCount = totalItemsCount,
                    Items = userViewModels
                };

                response.Data = pagination;
                response.isSuccess = true;
                response.Message = "Premium users retrieved successfully";
            }
            catch (DbException ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;

            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<ApiResponse<Pagination<PackagePremiumViewModel>>> GetPackagePremiumsAsync(int pageIndex, int pageSize)
        {
            var response = new ApiResponse<Pagination<PackagePremiumViewModel>>();

            try
            {
                var packagePremiums = await _unitOfWork.PackagePremiumRepository.GetAllAsync();
                var packagePreniumViewModels = _mapper.Map<List<PackagePremiumViewModel>>(packagePremiums);
                foreach (var packagePreniumViewModel in packagePreniumViewModels)
                {
                    var totalUsers = await _unitOfWork.PackageDetailRepository.GetTotalUsersByPackageIdAsync(packagePreniumViewModel.Id);
                    packagePreniumViewModel.TotalUsers = totalUsers;
                }
                var totalItemsCount = packagePreniumViewModels.Count;
                var pagination = new Pagination<PackagePremiumViewModel>
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                     TotalItemsCount = totalItemsCount,
                    Items = packagePreniumViewModels
                };

                response.Data = pagination;
                response.isSuccess = true;
                response.Message = "Package premiums retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ApiResponse<bool>> CreatePackageAsync(CreatePackagePremiumViewModel createPackagePremiumViewModel)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var package = _mapper.Map<PackagePremium>(createPackagePremiumViewModel);
                var packageList = _unitOfWork.PackagePremiumRepository.Find(s => s.PackagePremiumName == createPackagePremiumViewModel.PackagePremiumName);
                var isNameExist = packageList.Any();
                if (isNameExist)
                {
                    // throw new Exception("Tên  đã tồn tại!");
                    response.Data = false;
                    response.isSuccess = true;
                    response.Message = "Tên  đã tồn tại!";
                    return response;
                    
                }
                else
                {
                    FluentValidation.Results.ValidationResult validationResult = await  _validator.ValidateAsync(createPackagePremiumViewModel);
                    if (!validationResult.IsValid)
                    {
                        response.isSuccess = false;
                        response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                        return response;
                    }
                    else
                    {
                      
                        await _unitOfWork.PackagePremiumRepository.AddAsync(package);
                        var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                        if (isSuccess is false)
                        {
                            throw new Exception("Khởi tạo lỗi!");
                        }
                        response.Data= true;
                        response.isSuccess = true;
                        response.Message = "Tạo Thành Công !";

                    }
                }
            }
            catch (DbException ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;

            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;

        }

    

    public async Task<ApiResponse<Pagination<PackagePremiumViewModel>>> FilterPackageAsync(FilterPackagePremiumViewModel filterModel)
        {
            var response = new ApiResponse<Pagination<PackagePremiumViewModel>>();

            try
            {
                var paginationResult = await _unitOfWork.PackagePremiumRepository.GetFilterAsync(
                    filter: s =>
                        (string.IsNullOrEmpty(filterModel.PackagePremiumName) || s.PackagePremiumName.Contains(filterModel.PackagePremiumName)) &&
                        (filterModel.Price == 0 || s.Price == filterModel.Price) &&
                        (filterModel.Duration == 0 || s.Duration == filterModel.Duration) &&
                        (!filterModel.IsDeleted.HasValue || s.IsDeleted == filterModel.IsDeleted),
                      
                    pageIndex: filterModel.PageIndex,
                    pageSize: filterModel.PageSize
                ); ;
                var packageViewModels = _mapper.Map<List<PackagePremiumViewModel>>(paginationResult.Items);
                //dem user su dung package
                foreach (var packagePreniumViewModel in packageViewModels)
                {
                    var totalUsers = await _unitOfWork.PackageDetailRepository.GetTotalUsersByPackageIdAsync(packagePreniumViewModel.Id);
                    packagePreniumViewModel.TotalUsers = totalUsers;
                }
            /*    //  var totalItemsCount = packageViewModels.Count;*/
                var paginationViewModel = new Pagination<PackagePremiumViewModel>
                {
                    PageIndex = paginationResult.PageIndex,
                    PageSize = paginationResult.PageSize,
                    TotalItemsCount = paginationResult.TotalItemsCount,
                    Items = packageViewModels
                };
                response.Data = paginationViewModel;
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = "Error occurred while filtering skin types: " + ex.Message;
            }

            return response;
        }

        public async Task<ApiResponse<bool>> DeletePackageAsync(string id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var exist = await _unitOfWork.PackagePremiumRepository.GetByIdAsync(Guid.Parse(id));
                if (exist == null)
                {
                    
                    response.Data = false;
                    response.Message = "gói không tồn tại";
                    response.isSuccess = true;
                    return response;
                }
                if (exist.IsDeleted)
                {

                    response.Data = false;
                    response.Message = "gói đã được xóa";
                    response.isSuccess = true;
                    return response;

                }
                _unitOfWork.PackagePremiumRepository.SoftRemove(exist);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (isSuccess is false)
                {
                    throw new Exception("Xóa thất bại!");
                }
                response.Data = true;
                response.isSuccess = true;
                response.Message = "Xóa Thành Công!";
            }
            catch (DbException ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;

            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse<bool>> UpdatePackageAsync(CreatePackagePremiumViewModel createPackagePremiumViewModel, string id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(createPackagePremiumViewModel);
                if (!validationResult.IsValid)
                {
                    response.isSuccess = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }

                var exist = await _unitOfWork.PackagePremiumRepository.GetByIdAsync(Guid.Parse(id));
                if (exist is null)
                {
                    response.Message = "Gói không tồn tại";
                    response.isSuccess = false;
                    response.Data = false;
                    return response;
                }

                var update = _mapper.Map(createPackagePremiumViewModel, exist);
                var skinTypeList = _unitOfWork.PackagePremiumRepository.Find(s => s.PackagePremiumName == update.PackagePremiumName && s.Id != Guid.Parse(id));
                var isNameExist = skinTypeList.Any();
                if (isNameExist)
                {
                    response.Data = false;
                    response.Message = "Tên này đã tồn tại!";
                    response.isSuccess = false;
                    return response;
                }

                _unitOfWork.PackagePremiumRepository.Update(update);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;

                if (!isSuccess)
                {
                    throw new Exception("Cập nhật thất bại");
                }

                response.Data = true;
                response.isSuccess = true;
                response.Message = "Cập nhật thành công";
            }
            catch (DbException ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse<PackagePremiumViewModel>> GetPackagePremiumByIdAsync(string id)
        {
            var response = new ApiResponse<PackagePremiumViewModel>();
            try
            {
                var packagePremium = await _unitOfWork.PackagePremiumRepository.GetByIdAsync(Guid.Parse(id));
                if (packagePremium == null)
                {
                    response.Message = "Không tìm thấy !";

                    response.isSuccess = true;
                    response.Data = null;
                    return response;
                }

                var packagePremiumViewModel = _mapper.Map<PackagePremiumViewModel>(packagePremium);

                response.isSuccess = true;
                response.Data = packagePremiumViewModel;
            }
            catch (DbException ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;

            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
