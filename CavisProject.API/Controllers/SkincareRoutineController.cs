using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.Repositories;
using CavisProject.Application.ViewModels.ProductViewModel;
using CavisProject.Application.ViewModels.SkincareRoutineViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/skincare-routines")]
    [ApiController]
    public class SkincareRoutineController : ControllerBase
    {
        private ISkincareRoutineService _skincareRoutineService;
        public SkincareRoutineController(ISkincareRoutineService skincareRoutineService)
        {
            _skincareRoutineService = skincareRoutineService;
        }
        [SwaggerOperation(Summary = "cập nhật dưỡng da hàng ngày bằng id")]
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ApiResponse<bool>> UpdateSkincareRoutineByIdAsync([FromBody]  UpdateSkincareRoutineModel updateSkincareRoutineModel, Guid id) => await _skincareRoutineService.UpdateSkincareRoutineByIdAsync(updateSkincareRoutineModel, id);
    }
}
