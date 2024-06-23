using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.RegistPreniumViewModel;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Domain.Entity;
using FluentValidation;
using CavisProject.Application.ViewModels.UserViewModels;
using CavisProject.Domain.Enums;
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
using CavisProject.Application.ViewModels.PackagePremium;
using CavisProject.Application.Repositories;

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
        public async Task<ApiResponse<PackagePremiumViewModel>> RegisterPremiumAsync(string id)
        {
            var response = new ApiResponse<PackagePremiumViewModel>();
            try
            {
                var packagePremium = await _unitOfWork.PackagePremiumRepository.GetByIdAsync(Guid.Parse(id));
                if (packagePremium == null)
                {
                    throw new Exception("Package not found");
                }

                var userId = _claimsService.GetCurrentUserId;
                if (userId == Guid.Empty)
                {
                    response.isSuccess = true;
                    response.Data = null;
                    response.Message = "Đăng nhập !";
                    return response;
                }
                var existingPackageDetail = await _unitOfWork.PackageDetailRepository
          .FindAsync(pd => pd.UserId == userId.ToString() && (pd.Status == 0 || pd.Status == 1));

                if (existingPackageDetail != null)
                {
                    response.isSuccess = false;
                    response.Data = null;
                    response.Message = "Bạn đã có gói Premium đang chờ kích hoạt hoặc đang sử dụng!";
                    return response;
                }

                var expiredPackageDetail = await _unitOfWork.PackageDetailRepository
            .FindAsync(pd => pd.UserId == userId.ToString() && pd.PackagePremiumId == Guid.Parse(id) && pd.Status == 3 && pd.EndTime <= DateTime.UtcNow);

                if (expiredPackageDetail != null)
                {
                    expiredPackageDetail.Status = 0;
                    _unitOfWork.PackageDetailRepository.Update(expiredPackageDetail);
                }
                else
                {
                    var packageDetail = new PackageDetail
                    {
                        PackagePremiumId = Guid.Parse(id),
                        UserId = userId.ToString(),
                        Status = 0,
                    };

                    await _unitOfWork.PackageDetailRepository.AddAsync(packageDetail);
                }


                var transaction = new Transaction
                {
                    Id = Guid.NewGuid(),
                    Title = packagePremium.PackagePremiumName,
                    PurchaseTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),
                    TotalPaid = packagePremium.Price,
                    UserId = userId.ToString(),
                    PackagePremiumId = Guid.Parse(id),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                };

                await _unitOfWork.TransactionRepository.AddAsync(transaction);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (!isSuccess)
                {
                    response.isSuccess = false;
                    response.Message = "Đăng kí premium thất bại";
                    return response;
                }

                response.isSuccess = true;
                response.Message = "Đăng kí premium thành công !";
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

        public async Task<ApiResponse<UserPackageViewModel>> UpgradeToPremiumAsync(string id)
        {
            var response = new ApiResponse<UserPackageViewModel>();
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    throw new Exception("User not found");
                }

         
                var currentPackage = await _unitOfWork.PackageDetailRepository.GetByUserIdAsync(id);
                if (currentPackage == null)
                {
                    throw new Exception("Current package not found");
                }

                
                if (currentPackage.Status == 0)
                {
                    currentPackage.Status = 1; // Chuyển trạng thái gói từ chưa kích hoạt (0) sang đã kích hoạt (1)
                    _unitOfWork.PackageDetailRepository.Update(currentPackage);
                    if (currentPackage.PackagePremiumId.HasValue)
                    {
                        var packagePremium = await _unitOfWork.PackagePremiumRepository.GetByIdAsync(currentPackage.PackagePremiumId.Value);
                        if (packagePremium == null)
                        {
                            throw new Exception("PackagePremium not found for the current package.");
                        }

                        // Kiểm tra và cập nhật thời gian bắt đầu và kết thúc của gói Premium mới
                        currentPackage.StartTime = DateTime.UtcNow;
                        currentPackage.EndTime = DateTime.UtcNow.AddDays((int)packagePremium.Duration);
                    }
                    else
                    {
                        throw new Exception("PackagePremiumId is null for the current package.");
                    }
                    // Lưu thay đổi vào cơ sở dữ liệu
                    var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                    if (!isSuccess)
                    {
                        response.isSuccess = false;
                        response.Message = "Upgrade to premium failed.";
                        return response;
                    }
                }
                else
                {
                    response.isSuccess = false;
                    response.Message = "User already has an active premium package.";
                    return response;
                }

                response.isSuccess = true;
                response.Message = "Successfully upgraded to premium.";
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
                    response.Message = "Người dùng đã bị cấm.";
                }
                else
                {
                    await _userManager.SetLockoutEndDateAsync(user, null);
                    response.Data = true;
                    response.Message = "Hủy bỏ lệnh cấm người dùng thành công.";
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

                var usersPagination = await _unitOfWork.UserRepository.GetFilterAsync(
                    filter: search,
                    role: filterUserModel.Roles.ToString(),
                    isActivity: filterUserModel.IsActivity,
                    status: filterUserModel.StatusPremium, 
                    pageIndex: filterUserModel.PageIndex,
                    pageSize: filterUserModel.PageSize
                );

                if (usersPagination.Items.IsNullOrEmpty())
                {
                    response.Data = null;
                    response.isSuccess = true;
                    response.Message = "Không tìm thấy người dùng phù hợp!";
                }
                else
                {
                    var userViewModels = _mapper.Map<List<UserViewModel>>(usersPagination.Items);
                    foreach (var viewModel in userViewModels)
                    {
                        var packageDetail = await _unitOfWork.PackageDetailRepository.GetByUserIdAsync(viewModel.Id);
                        if (packageDetail != null)
                        {
                            viewModel.PackageDetail = _mapper.Map<PackageDetailViewModel>(packageDetail);
                        }
                    }

                    var result = new Pagination<UserViewModel>
                    {
                        PageIndex = usersPagination.PageIndex,
                        PageSize = usersPagination.PageSize,
                        TotalItemsCount = usersPagination.TotalItemsCount,
                        Items = userViewModels
                    };

                    response.Data = result;
                    response.isSuccess = true;
                    response.Message = "Successful!";
                }
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

                if (user == null)
                {
                    throw new Exception("User not found!"); 
                }

           
                var packageDetail = await _unitOfWork.PackageDetailRepository.GetByUserIdAsync(userId);

                var checkExist = await _unitOfWork.PersonalAnalystRepository.CheckExistPersonalAnalystAsync(userId);

                var userViewModel = _mapper.Map<UserViewModel>(user);
                userViewModel.PackageDetail = _mapper.Map<PackageDetailViewModel>(packageDetail); 

                userViewModel.CheckExistPersonal = checkExist;
                userViewModel.Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

                response.Data = userViewModel;
                response.isSuccess = true;
                response.Message = "Successful!";
            }
            catch (DbException ex)
            {
                response.Data = null;
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.isSuccess = false;
                response.Message = "An error occurred while fetching user info."; 
                                                                                  
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
                var packageDetail = await _unitOfWork.PackageDetailRepository.GetByUserIdAsync(id);
                UserViewModel userViewModel = _mapper.Map<UserViewModel>(user);
                userViewModel.PackageDetail = _mapper.Map<PackageDetailViewModel>(packageDetail);
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
                if (!string.IsNullOrEmpty(updateUserModel.URLImage)) user.URLImage = updateUserModel.URLImage;
                if(updateUserModel.DateOfBirth != null) user.DateOfBirth = updateUserModel.DateOfBirth;
                var newUser = await _userManager.UpdateAsync(user);
                if (!newUser.Succeeded)
                {
                    response.isSuccess = true;
                    response.Message = "Thay đổi thông tin thất bại!";
                    return response;
                }
                response.isSuccess = true;
                response.Message = "Thay đổi thông tin thành công!";
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
