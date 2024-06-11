﻿using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.UserViewModels;
using CavisProject.Domain.Entity;
using CavisProject.Domain.Enums;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdatePasswordModel> _updatePasswordValidator;
        private readonly IValidator<CreateUserModel> _createUserValidator;
        private readonly IValidator<UpdateUserModel> _updateUserValidator;

        public UserService(IClaimsService claimsService, IUnitOfWork unitOfWork,
            UserManager<User> userManager, RoleManager<Role> roleManager,
            IMapper mapper, IValidator<UpdatePasswordModel> updatePasswordValidator,
            IValidator<CreateUserModel> createUserValidator, IValidator<UpdateUserModel> updateUserValidator)
        {
            _claimsService = claimsService;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _updatePasswordValidator = updatePasswordValidator;
            _createUserValidator = createUserValidator;
            _updateUserValidator = updateUserValidator;
        }
        public async Task<ApiResponse<bool>> CreateUserAsync(CreateUserModel createUserModel)
        {
            var response = new ApiResponse<bool>();
            try
            {
                ValidationResult validationResult = await _createUserValidator.ValidateAsync(createUserModel);
                if (!validationResult.IsValid)
                {
                    response.Data = false;
                    response.isSuccess = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }
                var attributesToCheck = new List<(string AttributeValue, string AttributeType, string ErrorMessage)>
                {
                    (createUserModel.UserName!, "UserName", "UserName is existed!"),
                    (createUserModel.Email!, "Email", "Email is existed!"),
                    (createUserModel.PhoneNumber!, "PhoneNumber", "PhoneNumber is existed!")
                };
                foreach (var (attributeValue, attributeType, errorMessage) in attributesToCheck)
                {
                    if (await _unitOfWork.UserRepository.CheckUserAttributeExisted(attributeValue, attributeType))
                    {
                        response.Data = false;
                        response.isSuccess = true;
                        response.Message = errorMessage;
                        return response;
                    }
                }
                var user = _mapper.Map<User>(createUserModel);
                user.Wallet = 0;
                var identityResult = await _userManager.CreateAsync(user, user.PasswordHash);
                if (identityResult.Succeeded == false) throw new Exception(identityResult.Errors.ToString());

                if (string.IsNullOrEmpty(createUserModel.Roles))
                {
                    if (!await _roleManager.RoleExistsAsync(RolesEnum.Customer.ToString()))
                    {
                        await _roleManager.CreateAsync(new Role { Name = RolesEnum.Customer.ToString() });
                    }
                    await _userManager.AddToRoleAsync(user, RolesEnum.Customer.ToString());
                }
                else 
                {
                    if (!await _roleManager.RoleExistsAsync(createUserModel.Roles))
                    {
                        await _userManager.AddToRoleAsync(user, RolesEnum.Customer.ToString());
                        response.Data = false;
                        response.isSuccess = true;
                        response.Message = "Chọn vai trò không hợp lệ hệ tự động đưa về vai trò khách hàng";
                        return response;
                    }
                    await _userManager.AddToRoleAsync(user, createUserModel.Roles.ToString());
                }

                response.Data = true;
                response.isSuccess = true;
                response.Message = "Register is successful!";

            }
            catch (Exception ex)
            {
                response.Data = false;
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse<bool>> DeleteUserAsync(string id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var user = await _userManager.FindByIdAsync(id);

                if (user == null) throw new Exception("User not found!");
                if (await _userManager.IsInRoleAsync(user, AppRole.Admin))
                {
                    response.Data = false;
                    response.isSuccess = true;
                    response.Message = "Không thể khóa tài khoản này!";
                }
                if (user.LockoutEnd == null || user.LockoutEnd <= DateTimeOffset.UtcNow)
                {
                    var lockoutEndDate = DateTimeOffset.MaxValue;
                    await _userManager.SetLockoutEndDateAsync(user, lockoutEndDate);
                    response.Data = true;
                    response.Message = "User has been banned.";
                }
                else
                {
                    await _userManager.SetLockoutEndDateAsync(user, null);
                    response.Data = true;
                    response.Message = "User has been unbanned.";
                }
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse<Pagination<UserViewModel>>> FilterUserAsync(FilterUserModel filterUserModel)
        {
            var response = new ApiResponse<Pagination<UserViewModel>>();
            try
            {
                var search = (Expression<Func<User, bool>>)(e =>
                (string.IsNullOrEmpty(filterUserModel.Search) || e.UserName.Contains(filterUserModel.Search)
                || e.Email.Contains(filterUserModel.Search) || e.PhoneNumber.Contains(filterUserModel.Search))
                );
                var user = await _unitOfWork.UserRepository.GetFilterAsync(
                    filter: search,
                    role: filterUserModel.Roles.ToString(),
                    isActivity: filterUserModel.IsActivity,
                    pageIndex: filterUserModel.PageIndex,
                    pageSize: filterUserModel.PageSize
                    );
                if (user.Items.IsNullOrEmpty())
                {
                    response.Data = null;
                    response.isSuccess = true;
                    response.Message = "Không tìm thấy người dùng phù hợp!";
                }
                var result = _mapper.Map<Pagination<UserViewModel>>(user);

                response.Data = result;
                response.isSuccess = true;
                response.Message = "Successful!";

            }
            catch (Exception ex)
            {
                response.Data = null;
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse<UserViewModel>> GetInfoByLoginAsync()
        {
            var response = new ApiResponse<UserViewModel>();
            try
            {
                var userId = _claimsService.GetCurrentUserId.ToString();
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null) throw new Exception("Not found!");
                UserViewModel userViewModel = _mapper.Map<UserViewModel>(user);
                response.Data = userViewModel;
                response.isSuccess = true;
                response.Message = "Successful!";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse<UserViewModel>> GetUserByIdAsync(string id)
        {
            var response = new ApiResponse<UserViewModel>();
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null) throw new Exception("Not found!");
                UserViewModel userViewModel = _mapper.Map<UserViewModel>(user);
                response.Data = userViewModel;
                response.isSuccess = true;
                response.Message = "Successful!";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse<bool>> UpdatePasswordAsync(UpdatePasswordModel updatePasswordModel)
        {
            var response = new ApiResponse<bool>();
            try
            {
                ValidationResult validationResult = await _updatePasswordValidator.ValidateAsync(updatePasswordModel);
                if (!validationResult.IsValid)
                {
                    response.Data = false;
                    response.isSuccess = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }
                var userID = _claimsService.GetCurrentUserId;
                var user = await _userManager.FindByIdAsync(userID.ToString());
                if (user == null) throw new Exception("System Failure!");
                var newUser = await _userManager.ChangePasswordAsync(user, updatePasswordModel.OldPassword, updatePasswordModel.NewPassword);
                if (!newUser.Succeeded)
                {
                    response.isSuccess = true;
                    response.Message = "Thay đổi mật khẩu thất bại!";
                    return response;
                }
                response.isSuccess = true;
                response.Message = "Thay đổi mật khẩu thành công!";
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

        public async Task<ApiResponse<bool>> UpdateUserAsync(UpdateUserModel updateUserModel)
        {
            var response = new ApiResponse<bool>();
            try
            {
                ValidationResult validationResult = await _updateUserValidator.ValidateAsync(updateUserModel);
                if (!validationResult.IsValid)
                {
                    response.Data = false;
                    response.isSuccess = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }
                var userId = _claimsService.GetCurrentUserId;
                var user = await _userManager.FindByIdAsync(userId.ToString());
                if (user == null) throw new Exception("System Failure!");
                if(!string.IsNullOrEmpty(updateUserModel.Name)) user.FullName = updateUserModel.Name;
                if (!string.IsNullOrEmpty(updateUserModel.Gender)) user.Gender = updateUserModel.Gender;
                if (!string.IsNullOrEmpty(updateUserModel.PhoneNumber)) user.PhoneNumber = updateUserModel.PhoneNumber;
                if (!string.IsNullOrEmpty(updateUserModel.Email)) user.Email = updateUserModel.Email;
                if(updateUserModel.DateOfBird != null) user.DateOfBird = updateUserModel.DateOfBird;
                var newUser = await _userManager.UpdateAsync(user);
                if (!newUser.Succeeded)
                {
                    response.isSuccess = true;
                    response.Message = "Thay đổi mật khẩu thất bại!";
                    return response;
                }
                response.isSuccess = true;
                response.Message = "Thay đổi mật khẩu thành công!";
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
