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
       // [Authorize]
        public async Task<ApiResponse<bool>> CreateSkinConditionAsync([FromBody] CreateSkinTypeViewModel createSkinType) => await _skinConditionService.CreateSkinConditionAsync(createSkinType);
        [SwaggerOperation(Summary = "tìm thông tin triệu chứng về da")]
        [HttpGet("")]
        public async Task<ApiResponse<Pagination<SkinViewModel>>> FilterSkinConditionAsync(SkinFilterModel skinTypeFilterModel) => await _skinConditionService.FilterSkinConditionAsync(skinTypeFilterModel);
        [SwaggerOperation(Summary = "tìm thông tin triệu chứng về da bằng id")]
        [HttpGet("{id}")]
        public async Task<ApiResponse<SkinViewModel>> GetSkinConditionByIdAsync([FromRoute] string id) => await _skinConditionService.GetSkinConditionByIdAsync(id);
        [SwaggerOperation(Summary = "khóa thông tin triệu chứng về da bằng id {Authorize = Admin, Staff}")]
        [HttpDelete("{id}")]
      //  [Authorize]
        public async Task<ApiResponse<bool>> DeleteSkinConditionAsync([FromRoute] string id) => await _skinConditionService.DeleteSkinTypeAsync(id);
        [SwaggerOperation(Summary = "cập nhật thông tin triệu chứng về da bằng id {Authorize = Admin, Staff}")]
        [HttpPut("{id}")]
       // [Authorize]
        public async Task<ApiResponse<bool>> UpdateSkinCondition([FromBody] CreateSkinTypeViewModel updateSkinType, [FromRoute] string id) => await _skinConditionService.UpdateSkinConditionAsync(updateSkinType, id);

    }
}

