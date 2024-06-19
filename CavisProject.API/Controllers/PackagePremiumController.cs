using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.PackagePremium;
using CavisProject.Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/premium-packages")]
    [ApiController]
    public class PackagePremiumController :ControllerBase
    {
        private IPackagePreniumService _packagePremiumService;
        public PackagePremiumController(IPackagePreniumService packagePremiumService)
        {
            _packagePremiumService = packagePremiumService;
        }

        [HttpPost("")]
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Staff)]
        [SwaggerOperation(Summary = "tạo Package{Authorize = Admin}")]
        public async Task<ApiResponse<bool>> CreatePackageAsync(CreatePackagePremiumViewModel createPackagePremiumViewModel) => await _packagePremiumService.CreatePackageAsync(createPackagePremiumViewModel);

        [HttpGet("")]
        [SwaggerOperation(Summary = "filter Package")]
        public async Task<ApiResponse<Pagination<PackagePremiumViewModel>>> FilterPackageAsync([FromQuery] FilterPackagePremiumViewModel FilterModel) => await _packagePremiumService.FilterPackageAsync(FilterModel);
        [HttpPut("{id}")]
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Staff )]
        [SwaggerOperation(Summary = "Update Package {Authorize = Admin}")]
        public async Task<ApiResponse<bool>> UpdatePackage(CreatePackagePremiumViewModel createPackagePremiumViewModel, string Id) => await _packagePremiumService.UpdatePackageAsync(createPackagePremiumViewModel,Id);
        [HttpDelete("{id}")]
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Staff)]
        [SwaggerOperation(Summary = "xóa gói bằng Id {Authorize = Admin}")]
        public async Task<ApiResponse<bool>> DeletePackage(string Id)=> await _packagePremiumService.DeletePackageAsync(Id);
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "lấy thông tin gói bằng Id")]
        public async Task<ApiResponse<PackagePremiumViewModel>> GetPackagePremiumByIdAsync(string id) => await _packagePremiumService.GetPackagePremiumByIdAsync(id);
    }
}
