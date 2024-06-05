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
     
        public async Task<ApiResponse<Pagination<CreateSkinTypeViewModel>>> FilterSkinType(SkinFilterModel skinTypeFilterModel) => await _skintypeService.FilterSkinType(skinTypeFilterModel);

        [HttpDelete("{skinTypeId}")]
        public async Task<ApiResponse<bool>> DeleteSkinType([FromRoute] string skinTypeId)=> await _skintypeService.DeleteSkinType(skinTypeId);
        

        [HttpPut("{skinTypeId}")]
        public async Task<ApiResponse<CreateSkinTypeViewModel>> UpdateSkinType([FromBody] CreateSkinTypeViewModel updateSkinType, [FromRoute] string skinTypeId) => await _skintypeService.UpdateSkinType(updateSkinType, skinTypeId);
       
    }
}
