using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.PackagePremium;
using CavisProject.Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class PackagePremiumController :ControllerBase
    {
        private IPackagePreniumService _packagePreniumService;
        public PackagePremiumController(IPackagePreniumService packagePreniumService)
        {
            _packagePreniumService = packagePreniumService;
        }

        [HttpPost("package-premium")]
        [Authorize(Roles = AppRole.Admin)]
        [SwaggerOperation(Summary = "tạo Package{Authorize = Admin}")]
        public async Task<ApiResponse<bool>> CreatePackageAsync(CreatePackagePremiumViewModel createPackagePremiumViewModel) => await _packagePreniumService.CreatePackageAsync(createPackagePremiumViewModel);

        [HttpGet("mine/package-premium")]
        [SwaggerOperation(Summary = "filter Package")]
        public async Task<ApiResponse<Pagination<PackagePremiumViewModel>>> FilterPackageAsync([FromQuery] FilterPackagePremiumViewModel FilterModel) => await _packagePreniumService.FilterPackageAsync(FilterModel);
        [HttpPut("package-premium/{id}")]
        [Authorize(Roles = AppRole.Admin)]
        [SwaggerOperation(Summary = "Update Package {Authorize = Admin}")]
        public async Task<ApiResponse<bool>> UpdatePackage(CreatePackagePremiumViewModel createPackagePremiumViewModel, string Id) => await _packagePreniumService.UpdatePackageAsync(createPackagePremiumViewModel,Id);
        [HttpDelete("package-premium/{id}")]
        [Authorize(Roles = AppRole.Admin)]
        [SwaggerOperation(Summary = "Delete Package {Authorize = Admin}")]
        public async Task<ApiResponse<bool>> DeletePackage(string Id)=> await _packagePreniumService.DeletePackageAsync(Id);
        [HttpGet("package-premium/{id}")]
        [SwaggerOperation(Summary = "lấy thông tin gói bằng Id")]
        public async Task<ApiResponse<PackagePremiumViewModel>> GetPackagePremiumByIdAsync(string id) => await _packagePreniumService.GetPackagePremiumByIdAsync(id);
    }
}
