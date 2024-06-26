﻿using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.PackagePremiumViewModels;
using CavisProject.Application.ViewModels.RegistPreniumViewModel;
using CavisProject.Application.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse<PackagePremiumViewModel>> RegisterPremiumAsync(string id);
        Task<ApiResponse<UserPackageViewModel>> UpgradeToPremiumAsync(string id);
        Task<ApiResponse<UserViewModel>> GetUserByIdAsync(string id);
        Task<ApiResponse<UserViewModel>> GetInfoByLoginAsync();
        Task<ApiResponse<Pagination<UserViewModel>>> FilterUserAsync(FilterUserModel filterUserModel);
        Task<ApiResponse<bool>> UpdateUserAsync(UpdateUserModel updateUserModel);
        Task<ApiResponse<bool>> DeleteUserAsync(string id);
        Task<ApiResponse<bool>> CreateUserAsync(CreateUserModel createUserModel);
        Task<ApiResponse<bool>> UpdatePasswordAsync(UpdatePasswordModel updatePasswordModel);
        Task<ApiResponse<bool>> ApproveMethodAsync(string id);
    }
}
