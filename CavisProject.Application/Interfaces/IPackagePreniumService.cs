using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.PackagePremium;
using CavisProject.Application.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Interfaces
{
    public interface IPackagePreniumService
    {
        Task<ApiResponse<Pagination<UserViewModel>>> GetPremiumUsersAsync(int pageIndex, int pageSize);
        Task<ApiResponse<Pagination<PackagePreniumViewModel>>> GetPackagePremiumsAsync(int pageIndex, int pageSize);
    }
}
