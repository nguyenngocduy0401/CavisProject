using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.PersonalAnalystViewModels;
using CavisProject.Application.ViewModels.ProductViewModel;
using CavisProject.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

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

        /*[HttpGet("")]
        public async Task<ApiResponse<Pagination<ProductViewModel>>> SuggestProduct(string personalAnalystId)=> await _personalAnalystService.SuggestProduct(personalAnalystId);*/
        [HttpGet("mine")]
        public async Task<ApiResponse<Pagination<PersonalAnalystViewModel>>> FilterPersonalAnalystAsync(FilterPersonalAnalystModel filterPersonalAnalystModel) =>
            await _personalAnalystService.FilterPersonalAnalystAsync(filterPersonalAnalystModel);
        [HttpPost("mine")]
        public async Task<ApiResponse<bool>> FilterPersonalAnalystAsync([FromQuery]ListSkinPersonalModel listSkinPersonalModel) =>
            await _personalAnalystService.CreatePersonalAnalystByLoginAsync(listSkinPersonalModel);

    }
}
