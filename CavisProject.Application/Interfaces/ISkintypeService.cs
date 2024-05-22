using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.SkintypeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Interfaces
{
    public interface ISkintypeService
    {
        Task<ApiResponse<CreateSkinTypeViewModel>> CreateSkinType(CreateSkinTypeViewModel createSkinTypeViewModel);
        Task<ApiResponse<SkinTypeViewModel>> GetSKinType(SkinTypeViewModel skinTypeViewModel);
        Task<ApiResponse<CreateSkinTypeViewModel>> UpdateSkinType(CreateSkinTypeViewModel updateSkinType);
        Task<ApiResponse<bool>> DeleteSKinType(string skinTypeId);

    }
}
