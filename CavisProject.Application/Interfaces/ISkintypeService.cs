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
        Task<ApiResponse<CreateSkinTypeViewModel>> CreateSkinType(CreateSkinTypeViewModel createSkinType);
        Task<ApiResponse<Pagination<CreateSkinTypeViewModel>>> FilterSkinType(SkinFilterModel skinTypeFilterModel);
        Task<ApiResponse<bool>> DeleteSkinType(string skinTypeId);
        Task<ApiResponse<CreateSkinTypeViewModel>> UpdateSkinType(CreateSkinTypeViewModel updateSkinType, string skinTypeId);
    }
}
