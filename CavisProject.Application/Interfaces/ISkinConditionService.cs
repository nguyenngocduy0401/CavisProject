using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Interfaces
{
    public interface ISkinConditionService
    {
        Task<ApiResponse<bool>> CreateSkinConditionAsync(CreateSkinTypeViewModel createSkinType);
        Task<ApiResponse<Pagination<SkinViewModel>>> FilterSkinConditionAsync(SkinFilterModel skinTypeFilterModel);
        Task<ApiResponse<bool>> DeleteSkinTypeAsync(string skinTypeId);
        Task<ApiResponse<bool>> UpdateSkinConditionAsync(CreateSkinTypeViewModel updateSkinType, string skinTypeId);
        Task<ApiResponse<SkinViewModel>> GetSkinConditionByIdAsync(string id);
    }
}
