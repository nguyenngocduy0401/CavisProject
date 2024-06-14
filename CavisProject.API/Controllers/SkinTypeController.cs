using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace CavisProject.API.Controllers
{
    [Route("api/v1/skin-types")]
    public class SkinTypeController : ControllerBase
    {

        private readonly ISkintypeService _skinTypeService;
        public SkinTypeController(ISkintypeService skinTypeService) { _skinTypeService = skinTypeService; }
        [SwaggerOperation(Summary = "tạo thông tin loại da với (SkinCategory = 1 là loại da, = 2 triệu chứng về da) {Authorize = Admin, Staff}")]
        [HttpPost("")]
        [Authorize]
        public async Task<ApiResponse<CreateSkinTypeViewModel>> CreateSkinType([FromBody] CreateSkinTypeViewModel createSkinType) => await _skinTypeService.CreateSkinType(createSkinType);
        [SwaggerOperation(Summary = "tìm kiếm thông tin loại da ")]
        [HttpGet("")]
        public async Task<ApiResponse<Pagination<SkinViewModel>>> FilterSkinType(SkinFilterModel skinTypeFilterModel) 
            => await _skinTypeService.FilterSkinType(skinTypeFilterModel);
        [SwaggerOperation(Summary = "tìm kiếm thông tin loại da với id ")]
        [HttpGet("{id}")]
        public async Task<ApiResponse<SkinViewModel>> GetSkinTypeById([FromRoute] string id) => await _skinTypeService.GetSkinTypeById(id);
        [SwaggerOperation(Summary = "khóa thông tin loại da với id {Authorize = Admin, Staff}")]
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ApiResponse<bool>> DeleteSkinType([FromRoute] string id) => await _skinTypeService.DeleteSkinType(id);
        [SwaggerOperation(Summary = "cập nhật thông tin loại da với id {Authorize = Admin, Staff}")]
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ApiResponse<CreateSkinTypeViewModel>> UpdateSkinType([FromBody] CreateSkinTypeViewModel updateSkinType, [FromRoute] string id) => await _skinTypeService.UpdateSkinType(updateSkinType, id);
       
    }
}
