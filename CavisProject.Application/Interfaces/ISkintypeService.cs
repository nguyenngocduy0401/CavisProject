using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Interfaces
{
    public interface ISkintypeService
    {
        Task<ApiResponse<bool>> CreateSkinTypeAsync(CreateSkinTypeViewModel createSkinType);
        Task<ApiResponse<Pagination<SkinViewModel>>> FilterSkinTypeAsync(SkinFilterModel skinTypeFilterModel);
        Task<ApiResponse<bool>> DeleteSkinTypeAsync(string skinTypeId);
        Task<ApiResponse<bool>> UpdateSkinTypeAsync(CreateSkinTypeViewModel updateSkinType, string skinTypeId);
        Task<ApiResponse<SkinViewModel>> GetSkinTypeByIdAsync(string id);
    }
}
