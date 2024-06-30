using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.MethodViewModels;
using CavisProject.Application.ViewModels.PersonalAnalystViewModels;
using CavisProject.Application.ViewModels.ProductViewModel;
using CavisProject.Application.ViewModels.SkinTypeViewModels;
using CavisProject.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/personal-analysts")]
    public class PersonalAnalystController :ControllerBase
    {
        
        private readonly IPersonalAnalystService _personalAnalystService;
        public PersonalAnalystController(IPersonalAnalystService personalAnalystService)
        {
            _personalAnalystService = personalAnalystService;
        }
        [SwaggerOperation(Summary = "gợi ý sản phẩm")]
        [HttpGet("mine/products")]
        [Authorize]
        public async Task<ApiResponse<Pagination<ProductViewModel>>> SuggestProductAsync([FromQuery]FilterSuggestProductModel filterSuggestProductModel) => await _personalAnalystService.SuggestProductAsync(filterSuggestProductModel);
        [SwaggerOperation(Summary = "tìm kiếm các phân tích da của cá nhân")]
        [HttpGet("mine")]
        [Authorize]
        public async Task<ApiResponse<Pagination<PersonalAnalystViewModel>>> FilterPersonalAnalystAsync([FromQuery] FilterPersonalAnalystModel filterPersonalAnalystModel) =>
            await _personalAnalystService.FilterPersonalAnalystAsync(filterPersonalAnalystModel);
        [SwaggerOperation(Summary = "thêm các triệu chứng về da")]
        [HttpPost("mine")]
        [Authorize]
        public async Task<ApiResponse<bool>> CreatePersonalAnalystByLoginAsync([FromBody]ListSkinPersonalModel listSkinPersonalModel) =>
            await _personalAnalystService.CreatePersonalAnalystByLoginAsync(listSkinPersonalModel);
        [SwaggerOperation(Summary = "gợi ý phương pháp (phương pháp skincare và phương pháp makeup)")]
        [HttpGet("mine/methods")]
        [Authorize]
        public async Task<ApiResponse<Pagination<MethodViewModel>>> SuggestMethodAsync([FromQuery] FilterSuggestMethodModel filterSuggestMethodModel) => await _personalAnalystService.SuggestMethodMakeUpAsync(filterSuggestMethodModel);
        [SwaggerOperation(Summary = "lấy skin của người dùng khi đăng nhập")]
        [HttpGet("mine/skins")]
        [Authorize]
        public async Task<ApiResponse<SkinListViewModel>> SkinListAsync() => await _personalAnalystService.SkinListByLoginAsync();
    }
}
