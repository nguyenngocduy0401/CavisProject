using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.SupplierViewModel;
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
        public async Task<ApiResponse<CreateSupplierViewModel>> CreateSupplier([FromBody] CreateSupplierViewModel createSupplierViewModel)
        
           => await _supplierService.CreateSupplier(createSupplierViewModel);

        [SwaggerOperation(Summary = "tìm kiếm thông tin nhà cung cấp sản phẩm {Authorize = Admin, Staff}")]
        [HttpGet("")]
        public async Task<ApiResponse<Pagination<SupplierViewModel>>> FilterSupplier(FilterSupplierViewModel filterSupplierViewModel)
        => await _supplierService.FilterSupplier(filterSupplierViewModel);

        [SwaggerOperation(Summary = "khóa thông tin nhà cung cấp sản phẩm {Authorize = Admin, Staff}")]
        [HttpDelete("{id}")]
        public async Task<ApiResponse<bool>> DeleteSupplier([FromRoute] string supplierId)
        
          =>  await _supplierService.DeleteSupplier(supplierId);

        [SwaggerOperation(Summary = "cập nhật thông tin nhà cung cấp sản phẩm {Authorize = Admin, Staff}")]
        [HttpPut("{id}")]
        public async Task<ApiResponse<CreateSupplierViewModel>> UpdateSupplier([FromBody] CreateSupplierViewModel updateSupplierViewModel, [FromRoute] string id)
      =>   await _supplierService.UppdateSupplier(updateSupplierViewModel, id);
        
    }
}