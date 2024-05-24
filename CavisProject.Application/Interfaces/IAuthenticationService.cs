using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.RefreshTokenViewModels;
using CavisProject.Application.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ApiResponse<UserRegisterModel>> RegisterAsync(UserRegisterModel userRegisterModel);
        Task<ApiResponse<RefreshTokenModel>> LoginAsync(UserLoginModel userLoginModel);
        Task<ApiResponse<RefreshTokenModel>> RenewTokenAsync(RefreshTokenModel RefreshTokenModel);
        Task<ApiResponse<string>> LogoutAsync(string refreshToken);
    }
}
