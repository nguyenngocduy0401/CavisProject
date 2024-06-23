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
        Task<ApiResponse<bool>> CreateSkinType(CreateSkinTypeViewModel createSkinType);
        Task<ApiResponse<Pagination<SkinViewModel>>> FilterSkinType(SkinFilterModel skinTypeFilterModel);
        Task<ApiResponse<bool>> DeleteSkinType(string skinTypeId);
        Task<ApiResponse<bool>> UpdateSkinType(CreateSkinTypeViewModel updateSkinType, string skinTypeId);
        Task<ApiResponse<SkinViewModel>> GetSkinTypeById(string id);
    }
}
