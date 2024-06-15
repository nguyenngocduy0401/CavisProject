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

        [HttpPost("~/admin/api/v1/package-premium")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(Summary = "tạo Package{Authorize = Admin}")]
        public async Task<ApiResponse<CreatePackagePremiumViewModel>> CreatePackageAsync(CreatePackagePremiumViewModel createPackagePremiumViewModel) => await _packagePreniumService.CreatePackageAsync(createPackagePremiumViewModel);

        [HttpGet("mine/package-premium/filter")]
        [SwaggerOperation(Summary = "filter Package")]
        public async Task<ApiResponse<Pagination<PackagePreniumViewModel>>> FilterPackageAsync([FromQuery] FilterPackagePremiumViewModel FilterModel) => await _packagePreniumService.FilterPackageAsync(FilterModel);
        [HttpPost("~/admin/api/v1/package-premium/{id}")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(Summary = "Update Package {Authorize = Admin}")]
        public async Task<ApiResponse<CreatePackagePremiumViewModel>> UpdatePackage(CreatePackagePremiumViewModel createPackagePremiumViewModel, string Id) => await _packagePreniumService.UpdatePackageAsync(createPackagePremiumViewModel,Id);
        [HttpDelete("~/admin/api/v1/package-premium/{id}")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(Summary = "Delete Package {Authorize = Admin}")]
        public async Task<ApiResponse<bool>> DeletePackage(string Id)=> await _packagePreniumService.DeletePackageAsync(Id);
        [HttpGet("mine/package-premium/{id}")]
        [SwaggerOperation(Summary = "lấy thông tin gói bằng Id")]
        public async Task<ApiResponse<PackagePreniumViewModel>> GetPackagePremiumByIdAsync(string id) => await _packagePreniumService.GetPackagePremiumByIdAsync(id);
    }
}
