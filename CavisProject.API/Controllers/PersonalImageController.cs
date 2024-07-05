using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.PersonalImageViewModels;
using CavisProject.Application.ViewModels.ProductViewModel;
using CavisProject.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/personal-images")]
    [ApiController]
    public class PersonalImageController : ControllerBase
    {
        private readonly IPersonalImageService _personalImageService;
        public PersonalImageController(IPersonalImageService personalImageService)
        {
            _personalImageService = personalImageService;
        }
        [SwaggerOperation(Summary = "lấy thông tin ảnh chụp bằng Id ")]
        [HttpGet("{id}")]
        public async Task<ApiResponse<PersonalImageViewModel>> GetProductDetailByIdAsync(Guid id) =>
            await _personalImageService.GetPersonalImageByIdAsync(id);
    }
}
