using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using Microsoft.AspNetCore.Mvc;


namespace CavisProject.API.Controllers
{
    [Route("api/v1/skin-types")]
    public class SkinTypeController :ControllerBase
    {

        private  readonly ISkintypeService _skintypeService;
        public SkinTypeController(ISkintypeService skintypeService) { _skintypeService=skintypeService; }
        [HttpPost("")]
        public async Task<ApiResponse<CreateSkinTypeViewModel>> CreateSkinType([FromBody] CreateSkinTypeViewModel createSkinType) => await _skintypeService.CreateSkinType(createSkinType);


        [HttpGet("")]
     
        public async Task<ApiResponse<Pagination<SkinViewModel>>> FilterSkinType(SkinFilterModel skinTypeFilterModel) => await _skintypeService.FilterSkinType(skinTypeFilterModel);

        [HttpDelete("{id}")]
        public async Task<ApiResponse<bool>> DeleteSkinType([FromRoute] string id) => await _skintypeService.DeleteSkinType(id);
        

        [HttpPut("{id}")]
        public async Task<ApiResponse<CreateSkinTypeViewModel>> UpdateSkinType([FromBody] CreateSkinTypeViewModel updateSkinType, [FromRoute] string id) => await _skintypeService.UpdateSkinType(updateSkinType, id);
       
    }
}
