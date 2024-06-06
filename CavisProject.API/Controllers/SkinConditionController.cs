using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/skin-condition")]
    public class SkinConditionController: ControllerBase
    {
        private readonly ISkinConditionService _skinConditionService;
        public SkinConditionController(ISkinConditionService skinConditionService)
        {
            _skinConditionService = skinConditionService;
        }
        [HttpPost("")]
        public async Task<ApiResponse<CreateSkinTypeViewModel>> CreateSkinCondition([FromBody] CreateSkinTypeViewModel createSkinType) => await _skinConditionService.CreateSkinCondition(createSkinType);
        [HttpGet("")]
        public async Task<ApiResponse<Pagination<CreateSkinTypeViewModel>>> FilterSkinCondition(SkinFilterModel skinTypeFilterModel) => await _skinConditionService.FilterSkinCondition(skinTypeFilterModel);
        [HttpDelete("{skinTypeId}")]
        public async Task<ApiResponse<bool>> DeleteSkinCondition([FromRoute] string skinTypeId) => await _skinConditionService.DeleteSkinType(skinTypeId);


        [HttpPut("{skinTypeId}")]
        public async Task<ApiResponse<CreateSkinTypeViewModel>> UpdateSkinCondition([FromBody] CreateSkinTypeViewModel updateSkinType, [FromRoute] string skinTypeId) => await _skinConditionService.UpdateSkinCondition(updateSkinType, skinTypeId);
        [HttpGet("{skinTypeId}")]
        public async Task<ApiResponse<CreateSkinTypeViewModel>> GetSkinConditionById(string skinTypeId) => await _skinConditionService.GetSkinConditionById(skinTypeId);

    }
}

