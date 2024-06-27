using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.SupplierViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/suppliers")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        [SwaggerOperation(Summary = "tạo thông tin nhà cung cấp sản phẩm {Authorize = Admin, Staff}")]
        [HttpPost("")]
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Staff)]
        public async Task<ApiResponse<bool>> CreateSupplier([FromBody] CreateSupplierViewModel createSupplierViewModel)
        
           => await _supplierService.CreateSupplierAsync(createSupplierViewModel);

        [SwaggerOperation(Summary = "tìm kiếm thông tin nhà cung cấp sản phẩm")]
        [HttpGet("")]
        public async Task<ApiResponse<Pagination<SupplierViewModel>>> FilterSupplier(FilterSupplierViewModel filterSupplierViewModel)
        => await _supplierService.FilterSupplierAsync(filterSupplierViewModel);

        [SwaggerOperation(Summary = "khóa thông tin nhà cung cấp sản phẩm {Authorize = Admin, Staff}")]
        [HttpDelete("{id}")]
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Staff)]
        public async Task<ApiResponse<bool>> DeleteSupplier([FromRoute] string id)
        
          =>  await _supplierService.DeleteSupplierAsync(id);

        [SwaggerOperation(Summary = "cập nhật thông tin nhà cung cấp sản phẩm {Authorize = Admin, Staff}")]
        [HttpPut("{id}")]
        [Authorize(Roles = AppRole.Admin + "," + AppRole.Staff)]
        public async Task<ApiResponse<bool>> UpdateSupplier([FromBody] CreateSupplierViewModel updateSupplierViewModel, [FromRoute] string id)
      =>   await _supplierService.UpdateSupplierAsync(updateSupplierViewModel, id);
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "lấy thông tin nhà cung cấp sản phẩm  bằng id")]
        public async Task<ApiResponse<CreateSupplierViewModel>> GetSupplierByIdAsync(string id)=> await _supplierService.GetSupplierByIdAsync(id);
    }
}