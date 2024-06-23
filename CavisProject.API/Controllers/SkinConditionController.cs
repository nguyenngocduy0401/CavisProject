using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.Services;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(Summary = "tạo thông tin triệu chứng về da  {Authorize = Admin, Staff}")]
        [HttpPost("")]
        [Authorize]
        public async Task<ApiResponse<CreateSkinTypeViewModel>> CreateSkinCondition([FromBody] CreateSkinTypeViewModel createSkinType) => await _skinConditionService.CreateSkinCondition(createSkinType);
        [SwaggerOperation(Summary = "tìm thông tin triệu chứng về da")]
        [HttpGet("")]
        public async Task<ApiResponse<Pagination<SkinViewModel>>> FilterSkinCondition(SkinFilterModel skinTypeFilterModel) => await _skinConditionService.FilterSkinCondition(skinTypeFilterModel);
        [SwaggerOperation(Summary = "tìm thông tin triệu chứng về da bằng id")]
        [HttpGet("{id}")]
        public async Task<ApiResponse<SkinViewModel>> GetSkinConditionById([FromRoute] string id) => await _skinConditionService.GetSkinConditionById(id);
        [SwaggerOperation(Summary = "khóa thông tin triệu chứng về da bằng id {Authorize = Admin, Staff}")]
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ApiResponse<bool>> DeleteSkinCondition([FromRoute] string id) => await _skinConditionService.DeleteSkinType(id);
        [SwaggerOperation(Summary = "Cập nhật thông tin triệu chứng về da bằng id {Authorize = Admin, Staff}")]
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ApiResponse<CreateSkinTypeViewModel>> UpdateSkinCondition([FromBody] CreateSkinTypeViewModel updateSkinType, [FromRoute] string id) => await _skinConditionService.UpdateSkinCondition(updateSkinType, id);

    }
}

