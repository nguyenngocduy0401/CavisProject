using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.RegistPreniumViewModel;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Domain.Entity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public UserService(UserManager<User> userManager, IUnitOfWork unitOfWork, IMapper mapper, IClaimsService claimsService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _claimsService= claimsService;
            _userManager = userManager;
        }
        public async Task<ApiResponse<RegistPremiumViewModel>> RegistPremium(RegistPremiumViewModel registPremiumViewModel)
        {
            var response = new ApiResponse<RegistPremiumViewModel>();
            try
            {
                var packagePremium =await _unitOfWork.PackagePremiumRepository.GetByIdAsync(registPremiumViewModel.Id);
                if (packagePremium == null)
                {
                    throw new Exception("Package not found");

                }
                var userId = _claimsService.GetCurrentUserId;
                if (userId == Guid.Empty)
                {
                    response.isSuccess = false;
                    response.Message = "Register please";
                }
                var packageDetail = new PackageDetail
                {
                    PackagePremiumId = registPremiumViewModel.Id,
                    UserId = userId.ToString(),
                    Status = 0, 
                    StartTime = DateTime.UtcNow,
                    EndTime = DateTime.UtcNow.AddMonths(months: (int)packagePremium.Duration)
                };
                await _unitOfWork.PackageDetailRepository.AddAsync(packageDetail);
                 var transaction = new Transaction
                {
                    Id = Guid.NewGuid(),
                    Title = packagePremium.PackagePremiumName,
                    PurchaseTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),
                    TotalPaid = packagePremium.Price,
                 //   AppointmentId = Guid.NewGuid(),
                    UserId = userId.ToString(),
                    PackagePremiumId = registPremiumViewModel.Id,
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                await _unitOfWork.TransactionRepository.AddAsync(transaction);
               var isSuccess= await _unitOfWork.SaveChangeAsync()>0;
                if (isSuccess==false)
                {
                    response.isSuccess = false;
                    response.Message = "Premium package registered fail";
                }
                response.Data = registPremiumViewModel;
                response.isSuccess = true;
                response.Message = "Premium package registered successfully.";
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

        public async Task<ApiResponse<UpgradeToPremiumViewModel>> UpgradeToPremium(UpgradeToPremiumViewModel upgradeToPremiumViewModel)
        {
            var response = new ApiResponse<UpgradeToPremiumViewModel>();
            try
            {
                var user=await _userManager.FindByIdAsync(upgradeToPremiumViewModel.UserId);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
               
                var package =await _unitOfWork.PackageDetailRepository.GetByUserIdAsync(user.Id);
                if(package == null)
                {
                    throw new Exception("Not found");
                }
                package.Status = 1;
                await _userManager.AddToRoleAsync(user, "Premium");
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if(isSuccess==false)
                {
                    response.isSuccess = false;
                    response.Message = "Fail";
                }
             
                response.isSuccess = true;
                response.Message = "successfully.";
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
