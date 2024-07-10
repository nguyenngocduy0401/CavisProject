using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.MethodViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/methods")]
    public class MethodController:ControllerBase
    {
        
        private readonly IMethodMakeUpService _methodMakeUpService;
        public MethodController(IMethodMakeUpService methodMakeUpService) { _methodMakeUpService = methodMakeUpService; }
        [SwaggerOperation(Summary = "tìm kiếm thông tin phương pháp ( bao gồm cả skincare và makeup) với id ")]
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ApiResponse<MethodViewModel>> GetMethodByIdAsync(string id) => await _methodMakeUpService.GetMethodByIdAsync(id);
    }
}
}
