using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.PersonalAnalystViewModels;
using CavisProject.Application.ViewModels.ProductViewModel;
using CavisProject.Domain.Entity;
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
        [SwaggerOperation(Summary = "Gợi ý sản phẩm")]
        [HttpGet("mine/products")]
        public async Task<ApiResponse<Pagination<ProductViewModel>>> SuggestProductAsync([FromQuery]FilterSuggestProductModel filterSuggestProductModel) => await _personalAnalystService.SuggestProductAsync(filterSuggestProductModel);
        [SwaggerOperation(Summary = "Tìm kiếm các phân tích da của cá nhân")]
        [HttpGet("mine")]
        public async Task<ApiResponse<Pagination<PersonalAnalystViewModel>>> FilterPersonalAnalystAsync([FromQuery] FilterPersonalAnalystModel filterPersonalAnalystModel) =>
            await _personalAnalystService.FilterPersonalAnalystAsync(filterPersonalAnalystModel);
        [SwaggerOperation(Summary = "Thêm các triệu chứng về da")]
        [HttpPost("mine")]
        public async Task<ApiResponse<bool>> CreatePersonalAnalystByLoginAsync([FromBody]ListSkinPersonalModel listSkinPersonalModel) =>
            await _personalAnalystService.CreatePersonalAnalystByLoginAsync(listSkinPersonalModel);

    }
}
