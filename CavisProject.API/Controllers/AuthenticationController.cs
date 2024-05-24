using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.RefreshTokenViewModels;
using CavisProject.Application.ViewModels.UserViewModels;
using CavisProject.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("register")]
        public async Task<ApiResponse<UserRegisterModel>> RegisterAsync(UserRegisterModel userRegisterModel)
        {
            return await _authenticationService.RegisterAsync(userRegisterModel);

        }
        [HttpPost("login")]
        public async Task<ApiResponse<RefreshTokenModel>> LoginAsync(UserLoginModel userLoginModel)
        {
            return await _authenticationService.LoginAsync(userLoginModel);
        }
        [HttpPut("new-token")]
        public async Task<ApiResponse<RefreshTokenModel>> RenewTokenAsync(RefreshTokenModel refreshTokenModel)
        {
            return await _authenticationService.RenewTokenAsync(refreshTokenModel);
        }
        [HttpDelete("logout")]
        public async Task<ApiResponse<string>> LogoutAsync(string refreshToken)
        {
            return await _authenticationService.LogoutAsync(refreshToken);
        }
    }
}
