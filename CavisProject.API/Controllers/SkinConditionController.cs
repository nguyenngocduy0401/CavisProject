using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/skin-conditions")]
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
        public async Task<ApiResponse<Pagination<SkinViewModel>>> FilterSkinCondition(SkinFilterModel skinTypeFilterModel) => await _skinConditionService.FilterSkinCondition(skinTypeFilterModel);
        [HttpDelete("{id}")]
        public async Task<ApiResponse<bool>> DeleteSkinCondition([FromRoute] string id) => await _skinConditionService.DeleteSkinType(id);


        [HttpPut("{id}")]
        public async Task<ApiResponse<CreateSkinTypeViewModel>> UpdateSkinCondition([FromBody] CreateSkinTypeViewModel updateSkinType, [FromRoute] string id) => await _skinConditionService.UpdateSkinCondition(updateSkinType, id);

    }
}

