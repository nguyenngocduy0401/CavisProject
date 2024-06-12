using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.PackagePremium;
using CavisProject.Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CavisProject.API.Controllers
{
    [Route("api/premium-packages")]
    [ApiController]
    public class PackagePremiumController :ControllerBase
    {
        private IPackagePreniumService _packagePreniumService;
        public PackagePremiumController(IPackagePreniumService packagePreniumService)
        {
            _packagePreniumService = packagePreniumService;
        }
        [HttpGet("premiumUsers")]
      //  [Authorize(Roles = "Admin")]
        [SwaggerOperation(Summary = "Get các user đăng kí Premium")]
        public async Task<ApiResponse<Pagination<UserViewModel>>> GetPremiumUsersAsync([FromQuery] int pageIndex, int pageSize) => await _packagePreniumService.GetPremiumUsersAsync(pageIndex, pageSize);
        [HttpGet]
        [SwaggerOperation(Summary = "Get các gói Premium")]
        public async Task<ApiResponse<Pagination<PackagePreniumViewModel>>> GetPackagePremiumsAsync([FromQuery] int pageIndex, int pageSize) => await _packagePreniumService.GetPackagePremiumsAsync(pageIndex, pageSize);
    }
}
