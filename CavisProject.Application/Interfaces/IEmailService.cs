using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.EmailViewModels;
using CavisProject.Application.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Interfaces
{
    public interface IEmailService
    {
        Task<ApiResponse<bool>> SendOTPEmailAsync(string email);
        Task<ApiResponse<bool>> ResetPasswordAsync(string email, UserResetPasswordModel userResetPasswordModel);
    }
}
