using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.PackagePremium;
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
    public class PackagePreniumService : IPackagePreniumService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IValidator<CreatePackagePremiumViewModel> _validator;
        public PackagePreniumService(IValidator<CreatePackagePremiumViewModel> validator,UserManager<User> userManager,IUnitOfWork unitOfWork, IClaimsService claimsService, IMapper mapper)
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
                    userViewModel.PackagePremiumName = packagePremium?.PackagePremiumName;

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
        public async Task<ApiResponse<Pagination<PackagePreniumViewModel>>> GetPackagePremiumsAsync(int pageIndex, int pageSize)
        {
            var response = new ApiResponse<Pagination<PackagePreniumViewModel>>();

            try
            {
                var packagePremiums = await _unitOfWork.PackagePremiumRepository.GetAllAsync();
                var packagePreniumViewModels = _mapper.Map<List<PackagePreniumViewModel>>(packagePremiums);
                foreach (var packagePreniumViewModel in packagePreniumViewModels)
                {
                    var totalUsers = await _unitOfWork.PackageDetailRepository.GetTotalUsersByPackageIdAsync(packagePreniumViewModel.Id);
                    packagePreniumViewModel.TotalUsers = totalUsers;
                }
                var totalItemsCount = packagePreniumViewModels.Count;
                var pagination = new Pagination<PackagePreniumViewModel>
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

        public async Task<ApiResponse<CreatePackagePremiumViewModel>> CreatePackageAsync(CreatePackagePremiumViewModel createPackagePremiumViewModel)
        {
            var response = new ApiResponse<CreatePackagePremiumViewModel>();
            try
            {
                var package = _mapper.Map<PackagePremium>(createPackagePremiumViewModel);
                var packageList = _unitOfWork.PackagePremiumRepository.Find(s => s.PackagePremiumName == createPackagePremiumViewModel.PackagePremiumName);
                var isNameExist = packageList.Any();
                if (isNameExist)
                {
                    throw new Exception("Tên  đã tồn tại!");
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

    

    public async Task<ApiResponse<Pagination<PackagePreniumViewModel>>> FilterPackageAsync(FilterPackagePremiumViewModel filterModel)
        {
            var response = new ApiResponse<Pagination<PackagePreniumViewModel>>();

            try
            {
                var paginationResult = await _unitOfWork.PackagePremiumRepository.GetFilterAsync(
                    filter: s =>
                        (string.IsNullOrEmpty(filterModel.PackagePremiumName) || s.PackagePremiumName.Contains(filterModel.PackagePremiumName)) &&
                        (filterModel.Price == 0 || s.Price == filterModel.Price) &&
                        (filterModel.Duration == 0 || s.Duration == filterModel.Duration) ,
                      
                    pageIndex: filterModel.PageIndex,
                    pageSize: filterModel.PageSize
                ); ;
                var packageViewModels = _mapper.Map<List<PackagePreniumViewModel>>(paginationResult.Items);
                //dem user su dung package
                foreach (var packagePreniumViewModel in packageViewModels)
                {
                    var totalUsers = await _unitOfWork.PackageDetailRepository.GetTotalUsersByPackageIdAsync(packagePreniumViewModel.Id);
                    packagePreniumViewModel.TotalUsers = totalUsers;
                }
            /*    //  var totalItemsCount = packageViewModels.Count;*/
                var paginationViewModel = new Pagination<PackagePreniumViewModel>
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

        public async Task<ApiResponse<bool>> DeletePackageAsync(string Id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var exist = await _unitOfWork.PackagePremiumRepository.GetByIdAsync(Guid.Parse(Id));
                if (exist == null)
                {
                    throw new Exception("Không tồn tại");
                }
                if (exist.IsDeleted)
                {

                    throw new Exception("đã được xóa");

                }
                _unitOfWork.PackagePremiumRepository.SoftRemove(exist);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (isSuccess is false)
                {
                    throw new Exception("Xóa thất bại!");
                }
                response.Data = _mapper.Map<bool>(Id);
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

        public async Task<ApiResponse<CreatePackagePremiumViewModel>> UpdatePackageAsync(CreatePackagePremiumViewModel createPackagePremiumViewModel, string Id)
        {
            var response = new ApiResponse<CreatePackagePremiumViewModel>();
            try
            {
                var exist = await _unitOfWork.PackagePremiumRepository.GetByIdAsync(Guid.Parse(Id));               
                    if (exist is null)
                    {
                        throw new Exception("Gói không tồn tại");

                    }
                    else
                    {
                        var update = _mapper.Map(createPackagePremiumViewModel, exist);
                        var skinTypeList = _unitOfWork.PackagePremiumRepository.Find(s => s.PackagePremiumName == update.PackagePremiumName);
                        var isNameExist = skinTypeList.Any();
                        if (isNameExist)
                        {
                            throw new Exception("Tên này đã tồn tại!");
                        }
                        FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(createPackagePremiumViewModel);
                        if (validationResult.IsValid)
                        {
                            response.isSuccess = false;
                            response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                            return response;
                        }
                    var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;

                        if (isSuccess is false)
                        {
                            throw new Exception("Cập nhật thất bại");
                        }
                        response.Data = _mapper.Map<CreatePackagePremiumViewModel>(Id);
                        response.isSuccess = true;
                        response.Message = "Cập nhật thành công";
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
        public async Task<ApiResponse<PackagePreniumViewModel>> GetPackagePremiumByIdAsync(string id)
        {
            var response = new ApiResponse<PackagePreniumViewModel>();
            try
            {
                var packagePremium = await _unitOfWork.PackagePremiumRepository.GetByIdAsync(Guid.Parse(id));
                if (packagePremium == null)
                {
                    throw new Exception("Không tìm thấy !");
                }

                var packagePremiumViewModel = _mapper.Map<PackagePreniumViewModel>(packagePremium);

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
