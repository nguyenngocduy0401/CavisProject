using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.MethodViewModels;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Interfaces
{
    public interface IMethodSkinCareService
    {
        Task<ApiResponse<bool>> CreateMethodSkinCareAsync(CreateMethodViewModel create);
        Task<ApiResponse<Pagination<MethodViewModel>>> FilterMethodSkinCareAsync(FilterMethodSkinCareViewModel filterModel);
        Task<ApiResponse<bool>> DeleteMethodSkinCareAsync(string id);
        Task<ApiResponse<bool>> UpdateMethodSkinCareAsync(CreateMethodViewModel update, string id);
        Task<ApiResponse<MethodViewModel>> GetMethodSkinCareById(string id);
    }
}
