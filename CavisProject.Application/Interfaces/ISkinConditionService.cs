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
        Task<ApiResponse<bool>> CreateSkinCondition(CreateSkinTypeViewModel createSkinType);
        Task<ApiResponse<Pagination<SkinViewModel>>> FilterSkinCondition(SkinFilterModel skinTypeFilterModel);
        Task<ApiResponse<bool>> DeleteSkinType(string skinTypeId);
        Task<ApiResponse<bool>> UpdateSkinCondition(CreateSkinTypeViewModel updateSkinType, string skinTypeId);
        Task<ApiResponse<SkinViewModel>> GetSkinConditionById(string id);
    }
}
