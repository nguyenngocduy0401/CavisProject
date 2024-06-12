using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.PackagePremium;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Application.ViewModels.UserViewModels;
using CavisProject.Domain.Entity;
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
        public PackagePreniumService(UserManager<User> userManager,IUnitOfWork unitOfWork, IClaimsService claimsService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _claimsService = claimsService;
            _mapper = mapper;
            _userManager= userManager;
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

    }
}
