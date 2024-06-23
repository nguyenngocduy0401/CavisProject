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
        [SwaggerOperation(Summary = "tạo gói {Authorize = Admin, Staff}")]
        public async Task<ApiResponse<bool>> CreatePackageAsync(CreatePackagePremiumViewModel createPackagePremiumViewModel) => await _packagePremiumService.CreatePackageAsync(createPackagePremiumViewModel);

        [HttpGet("")]
        [SwaggerOperation(Summary = "tìm kiếm gói")]
        public async Task<ApiResponse<Pagination<PackagePreniumViewModel>>> FilterPackageAsync([FromQuery] FilterPackagePremiumViewModel FilterModel) => await _packagePremiumService.FilterPackageAsync(FilterModel);
        [HttpPut("{id}")]
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Staff )]
        [SwaggerOperation(Summary = "cập nhật gói bằng id {Authorize = Admin, Staff}")]
        public async Task<ApiResponse<bool>> UpdatePackage(CreatePackagePremiumViewModel createPackagePremiumViewModel, string id) => await _packagePremiumService.UpdatePackageAsync(createPackagePremiumViewModel,id);
        [HttpDelete("{id}")]
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Staff)]
        [SwaggerOperation(Summary = "xóa gói bằng id {Authorize = Admin, Staff}")]
        public async Task<ApiResponse<bool>> DeletePackage(string id)=> await _packagePremiumService.DeletePackageAsync(id);
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "lấy thông tin gói bằng id")]
        public async Task<ApiResponse<PackagePreniumViewModel>> GetPackagePremiumByIdAsync(string id) => await _packagePremiumService.GetPackagePremiumByIdAsync(id);
    }
}
