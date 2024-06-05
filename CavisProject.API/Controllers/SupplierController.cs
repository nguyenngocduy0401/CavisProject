using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.SupplierViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/supplier")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpPost("")]
        public async Task<ApiResponse<CreateSupplierViewModel>> CreateSupplier([FromBody] CreateSupplierViewModel createSupplierViewModel)
        
           => await _supplierService.CreateSupplier(createSupplierViewModel);
        

        [HttpGet("")]
        public async Task<ApiResponse<Pagination<CreateSupplierViewModel>>> FilterSupplier(FilterSupplierViewModel filterSupplierViewModel)
        => await _supplierService.FilterSupplier(filterSupplierViewModel);
       

        [HttpDelete("{supplierId}")]
        public async Task<ApiResponse<bool>> DeleteSupplier([FromRoute] string supplierId)
        
          =>  await _supplierService.DeleteSupplier(supplierId);
        

        [HttpPut("{supplierId}")]
        public async Task<ApiResponse<CreateSupplierViewModel>> UpdateSupplier([FromBody] CreateSupplierViewModel updateSupplierViewModel, [FromRoute] string supplierId)
      =>   await _supplierService.UppdateSupplier(updateSupplierViewModel, supplierId);
        
    }
}