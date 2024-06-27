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
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Staff)]
        public async Task<ApiResponse<bool>> CreateSkinTypeAsync([FromBody] CreateSkinTypeViewModel createSkinType) => await _skinTypeService.CreateSkinTypeAsync(createSkinType);
        [SwaggerOperation(Summary = "tìm kiếm thông tin loại da ")]
        [HttpGet("")]
        public async Task<ApiResponse<Pagination<SkinViewModel>>> FilterSkinTypeAsync(SkinTypeFilterModel skinTypeFilterModel) 
            => await _skinTypeService.FilterSkinTypeAsync(skinTypeFilterModel);
        [SwaggerOperation(Summary = "tìm kiếm thông tin loại da với id ")]
        [HttpGet("{id}")]
        public async Task<ApiResponse<SkinViewModel>> GetSkinTypeByIdAsync([FromRoute] string id) => await _skinTypeService.GetSkinTypeByIdAsync(id);
        [SwaggerOperation(Summary = "khóa thông tin loại da với id {Authorize = Admin, Staff}")]
        [HttpDelete("{id}")]
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Staff)]
        public async Task<ApiResponse<bool>> DeleteSkinTypeAsync([FromRoute] string id) => await _skinTypeService.DeleteSkinTypeAsync(id);
        [SwaggerOperation(Summary = "cập nhật thông tin loại da với id {Authorize = Admin, Staff}")]
        [HttpPut("{id}")]
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Staff)]
        public async Task<ApiResponse<bool>> UpdateSkinTypeAsync([FromBody] CreateSkinTypeViewModel updateSkinType, [FromRoute] string id) => await _skinTypeService.UpdateSkinTypeAsync(updateSkinType, id);
       
    }
}
