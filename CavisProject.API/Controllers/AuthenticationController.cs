﻿using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.EmailViewModels;
using CavisProject.Application.ViewModels.RefreshTokenViewModels;
using CavisProject.Application.ViewModels.UserViewModels;
using CavisProject.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IEmailService _emailService;
        public AuthenticationController(IAuthenticationService authenticationService, IEmailService emailService)
        {
            _authenticationService = authenticationService;
            _emailService = emailService;
        }
        [SwaggerOperation(Summary = "đăng kí tài khoản")]
        [HttpPost("register")]
        public async Task<ApiResponse<UserRegisterModel>> RegisterAsync(UserRegisterModel userRegisterModel)
        {
            return await _authenticationService.RegisterAsync(userRegisterModel);

        }
        [SwaggerOperation(Summary = "đăng nhập bằng UserName và Password")]
        [HttpPost("login")]
        public async Task<ApiResponse<RefreshTokenModel>> LoginAsync(UserLoginModel userLoginModel)
        {
            return await _authenticationService.LoginAsync(userLoginModel);
        }
        [HttpPost("otp-email")]
        public async Task<ApiResponse<bool>> OTPEmailAsync(OTPEmailModel otpEmailModel)
        {
            return await _emailService.SendOTPEmailAsync(otpEmailModel);
        }
        [HttpPut("reset-password/{email}")]
        public async Task<ApiResponse<bool>> ResetPasswordAsync(string email, UserResetPasswordModel userResetPasswordModel)
        {
            return await _emailService.ResetPasswordAsync(email, userResetPasswordModel);
        }
        [HttpPut("new-token")]
        public async Task<ApiResponse<RefreshTokenModel>> RenewTokenAsync(RefreshTokenModel refreshTokenModel)
        {
            return await _authenticationService.RenewTokenAsync(refreshTokenModel);
        }
        [Authorize]
        [HttpDelete("logout")]
        public async Task<ApiResponse<string>> LogoutAsync(string refreshToken)
        {
            return await _authenticationService.LogoutAsync(refreshToken);
        }
    }
}
