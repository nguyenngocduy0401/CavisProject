using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CavisProject.API.Controllers
{
    public class SkinTypeController :ControllerBase
    {
        private  readonly ISkintypeService _skintypeService;
        public SkinTypeController(ISkintypeService skintypeService) { _skintypeService=skintypeService; }
        [HttpPost("create-skin-types")]
        public async Task<ApiResponse<CreateSkinTypeViewModel>> CreateSkinType([FromBody] CreateSkinTypeViewModel createSkinType) => await _skintypeService.CreateSkinType(createSkinType);
      

        [HttpGet("get-skin-types")]
        public async Task<ApiResponse<List<SkinTypeViewModel>>> GetSkinTypes() => await _skintypeService.GetSkinType();


        [HttpGet("get-skin-conditions")]
        public async Task<ApiResponse<List<SkinTypeViewModel>>> GetSkinConditions() => await _skintypeService.GetSkinConditions();
        

        [HttpDelete("delete-skin-types/{skinTypeId}")]
        public async Task<ApiResponse<bool>> DeleteSkinType([FromRoute] string skinTypeId)=> await _skintypeService.DeleteSkinType(skinTypeId);
        

        [HttpPut("update-skin-types/{skinTypeId}")]
        public async Task<ApiResponse<CreateSkinTypeViewModel>> UpdateSkinType([FromBody] CreateSkinTypeViewModel updateSkinType, [FromRoute] string skinTypeId) => await _skintypeService.UpdateSkinType(updateSkinType, skinTypeId);
       
    }
}
