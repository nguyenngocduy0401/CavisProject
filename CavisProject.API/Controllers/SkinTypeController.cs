using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using Microsoft.AspNetCore.Mvc;


namespace CavisProject.API.Controllers
{
    [Route("api/v1/skin-types")]
    public class SkinTypeController : ControllerBase
    {

        private readonly ISkintypeService _skinTypeService;
        public SkinTypeController(ISkintypeService skinTypeService) { _skinTypeService = skinTypeService; }
        [HttpPost("")]
        public async Task<ApiResponse<CreateSkinTypeViewModel>> CreateSkinType([FromBody] CreateSkinTypeViewModel createSkinType) => await _skinTypeService.CreateSkinType(createSkinType);


        [HttpGet("")]
        public async Task<ApiResponse<Pagination<SkinViewModel>>> FilterSkinType(SkinFilterModel skinTypeFilterModel) 
            => await _skinTypeService.FilterSkinType(skinTypeFilterModel);

        [HttpGet("{id}")]
        public async Task<ApiResponse<SkinViewModel>> GetSkinTypeById([FromRoute] string id) => await _skinTypeService.GetSkinTypeById(id);

        [HttpDelete("{id}")]
        public async Task<ApiResponse<bool>> DeleteSkinType([FromRoute] string id) => await _skinTypeService.DeleteSkinType(id);
        

        [HttpPut("{id}")]
        public async Task<ApiResponse<CreateSkinTypeViewModel>> UpdateSkinType([FromBody] CreateSkinTypeViewModel updateSkinType, [FromRoute] string id) => await _skinTypeService.UpdateSkinType(updateSkinType, id);
       
    }
}
