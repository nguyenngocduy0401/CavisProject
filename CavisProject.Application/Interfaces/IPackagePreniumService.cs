using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.PackagePremium;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
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
        Task<ApiResponse<Pagination<PackagePremiumViewModel>>> GetPackagePremiumsAsync(int pageIndex, int pageSize);
        Task<ApiResponse<bool>> CreatePackageAsync(CreatePackagePremiumViewModel createPackagePremiumViewModel);
        Task<ApiResponse<Pagination<PackagePremiumViewModel>>> FilterPackageAsync(FilterPackagePremiumViewModel FilterModel);
        Task<ApiResponse<bool>> DeletePackageAsync(string id);
        Task<ApiResponse<bool>> UpdatePackageAsync(CreatePackagePremiumViewModel createPackagePremiumViewModel, string id);
        Task<ApiResponse<PackagePremiumViewModel>> GetPackagePremiumByIdAsync(string id);
    }
}
