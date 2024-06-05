using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.ProductViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/product-categorys")]
    public class PersonalAnalystController :ControllerBase
    {
        
        private readonly IPersonalAnalystService _personalAnalystService;
        public PersonalAnalystController(IPersonalAnalystService personalAnalystService)
        {
            _personalAnalystService = personalAnalystService;
        }
        [HttpGet("")]
        public async Task<ApiResponse<Pagination<ProductViewModel>>> SuggestProduct(string personalAnalystId)=> await _personalAnalystService.SuggestProduct(personalAnalystId);
    }
}
