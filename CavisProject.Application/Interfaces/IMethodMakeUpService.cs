using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.MethodViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Interfaces
{
    public  interface IMethodMakeUpService
    {
        Task<ApiResponse<bool>> CreateMethodSkinMakeUpAsync(CreateMethodViewModel create);
        Task<ApiResponse<Pagination<MethodViewModel>>> FilterMethodSkinMakeUpAsync(FilterMethodSkinCareViewModel filterModel);
        Task<ApiResponse<bool>> DeleteMethodMakeUpAsync(string id);
        Task<ApiResponse<bool>> UpdateMethodMakeUpAsync(CreateMethodViewModel update, string id);
        Task<ApiResponse<MethodViewModel>> GetMethodMakeUpByIdAsync(string id);
    }
}
