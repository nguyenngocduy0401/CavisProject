using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.Repositories;
using CavisProject.Application.ViewModels.ProductCategoryViewModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/product-categories")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }
        [SwaggerOperation(Summary = "tạo thông tin loại sản phẩm {Authorize = Admin, Staff}")]
        [HttpPost("")]
        public async Task<ApiResponse<CreateProductCategoryViewModel>> CreateProductCategory([FromBody] CreateProductCategoryViewModel createProductCategoryViewModel)
        => await _productCategoryService.CreateProductCategory(createProductCategoryViewModel);

        [SwaggerOperation(Summary = "xóa thông tin loại sản phẩm bằng id {Authorize = Admin, Staff}")]
        [HttpDelete("{id}")]
        public async Task<ApiResponse<bool>> DeleteProductCategory(string id)
        => await _productCategoryService.DeleteProductCategory(id);
        [SwaggerOperation(Summary = "cập nhật thông tin loại sản phẩm bằng id {Authorize = Admin, Staff}")]
        [HttpPut("{id}")]
        public async Task<ApiResponse<CreateProductCategoryViewModel>> UpdateProductCategory([FromBody] CreateProductCategoryViewModel createProductCategoryViewModel, [FromRoute] string id)
       =>  await _productCategoryService.UppdateProductCategory(createProductCategoryViewModel, id);
        [SwaggerOperation(Summary = "tìm kiếm thông tin loại sản phẩm {Authorize = Admin, Staff}")]
        [HttpGet("")]
        public async Task<ApiResponse<Pagination<ProductCategoryViewModel>>> FilterProductCategory(FilterProductCategoryModel filterProductCategory)
       => await _productCategoryService.FilterProductCategory(filterProductCategory);
        [SwaggerOperation(Summary = "lấy thông tin loại sản phẩm bằng id")]
        [HttpGet("{id}")]
       
        public async Task<ApiResponse<ProductCategoryViewModel>> GetProductCategoryByIdAsync(string id) => await _productCategoryService.GetProductCategoryByIdAsync(id);
    }
}
