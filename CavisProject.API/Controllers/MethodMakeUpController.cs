using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.MethodViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/method-make-up")]
    // [Authorize]
    public class MethodMakeUpController
    {
        private readonly IMethodMakeUpService _methodMakeUpService;
        public MethodMakeUpController(IMethodMakeUpService methodMakeUpService) { _methodMakeUpService = methodMakeUpService; }
        [SwaggerOperation(Summary = "tạo thông tin phương pháp MakeUp {Authorize = Admin, Staff}")]
        [HttpPost("")]
        // [Authorize(Roles = AppRole.Admin + "," + AppRole.Staff)]
        public async Task<ApiResponse<bool>> CreateMethodMakeUp([FromBody] CreateMethodViewModel model) => await _methodMakeUpService.CreateMethodSkinMakeUpAsync(model);
        [SwaggerOperation(Summary = "tìm kiếm thông tin loại phương pháp MakeUp ")]
        [HttpGet("")]
        public async Task<ApiResponse<Pagination<MethodViewModel>>> FilterMethodMakeUp(FilterMethodSkinCareViewModel filter) => await _methodMakeUpService.FilterMethodSkinMakeUpAsync(filter);
        [SwaggerOperation(Summary = "tìm kiếm thông tin phương pháp MakeUp với id ")]
        [HttpGet("{id}")]
        public async Task<ApiResponse<MethodViewModel>> GetMethodMakeUpById(string id) => await _methodMakeUpService.GetMethodMakeUpByIdAsync(id);
        [SwaggerOperation(Summary = "khóa thông tin phương pháp MakeUp với id {Authorize = Admin, Staff}")]
        [HttpDelete("{id}")]
        // [Authorize(Roles = AppRole.Admin + "," + AppRole.Staff)]
        public async Task<ApiResponse<bool>> DeleteMethodMakeUp(string id) => await _methodMakeUpService.DeleteMethodMakeUpAsync(id);
        [SwaggerOperation(Summary = "cập nhật thông tin phương pháp MakeUp với id {Authorize = Admin, Staff}")]
        [HttpPut("{id}")]
        // [Authorize(Roles = AppRole.Admin + "," + AppRole.Staff)]
        public async Task<ApiResponse<bool>> UpdateMethodMakeUp([FromBody] CreateMethodViewModel model, string id) => await _methodMakeUpService.UpdateMethodMakeUpAsync(model, id);
    }
}
