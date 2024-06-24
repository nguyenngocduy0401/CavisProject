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
    public class PackagePremiumController : ControllerBase
    {
        private IPackagePreniumService _packagePremiumService;
        public PackagePremiumController(IPackagePreniumService packagePremiumService)
        {
            _packagePremiumService = packagePremiumService;
        }

        [HttpPost("")]
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Staff)]
        [SwaggerOperation(Summary = "tạo Package{Authorize = Admin}")]
        public async Task<ApiResponse<bool>> CreatePackageAsync([FromBody] CreatePackagePremiumViewModel createPackagePremiumViewModel) => await _packagePremiumService.CreatePackageAsync(createPackagePremiumViewModel);

        [HttpGet("")]
        [SwaggerOperation(Summary = "tìm kiếm thông tin gói")]
        public async Task<ApiResponse<Pagination<PackagePremiumViewModel>>> FilterPackageAsync([FromQuery] FilterPackagePremiumViewModel filterModel) => await _packagePremiumService.FilterPackageAsync(filterModel);
        [HttpPut("{id}")]
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Staff)]
        [SwaggerOperation(Summary = "cập nhât thông tin gói bằng Id {Authorize = Admin}")]
        public async Task<ApiResponse<bool>> UpdatePackage([FromBody] CreatePackagePremiumViewModel createPackagePremiumViewModel, string id) => await _packagePremiumService.UpdatePackageAsync(createPackagePremiumViewModel, id);
        [HttpDelete("{id}")]
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Staff)]
        [SwaggerOperation(Summary = "xóa gói bằng Id {Authorize = Admin}")]
        public async Task<ApiResponse<bool>> DeletePackage(string id) => await _packagePremiumService.DeletePackageAsync(id);
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "lấy thông tin gói bằng Id")]
        public async Task<ApiResponse<PackagePremiumViewModel>> GetPackagePremiumByIdAsync(string id) => await _packagePremiumService.GetPackagePremiumByIdAsync(id);
    }
}
