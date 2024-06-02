using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.EmailViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Interfaces
{
    public interface IEmailService
    {
        Task<ApiResponse<bool>> SendOTPEmail(string email);
    }
}
