using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.Services;
using CavisProject.Application.ViewModels.ProductCategoryViewModel;
using CavisProject.Application.ViewModels.ProductViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CavisProject.API.Controllers
{ [Route("api/v1/product")]
    [Authorize]
    public class ProductController : ControllerBase 
       
    {
     
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [SwaggerOperation(Summary = "lấy thông tin sản phẩm bằng Id ")]
        [HttpGet("{id}")]
        public async Task<ApiResponse<ProductViewModel>> GetProductDetailById(string id) =>
            await _productService.GetProductDetailByIdAsync(id);
        [SwaggerOperation(Summary = "tạo mới sản phẩm {Authorize=Admin,Staff)")]
        [HttpPost]
        public async Task<ApiResponse<bool>> CreateProduct(CreateProductViewModel createProductViewModel) => await _productService.CreateProduct(createProductViewModel);
        [SwaggerOperation(Summary = "xóa sản phẩm {Authorize=Admin)")]
        [HttpDelete("{id}")]
        public async Task<ApiResponse<bool>> DeleteProduct(string id) => await _productService.DeleteProduct(id);
        [SwaggerOperation(Summary = "lọc sản phẩm ")]
        [HttpGet]
        public async Task<ApiResponse<Pagination<ProductViewModel>>> Filter(FilterProductViewModel filterProductViewModel) => await _productService.Filter(filterProductViewModel);
        [SwaggerOperation(Summary = "cập nhật sản phẩm{Authorize=Admin}")]
        [HttpPut("{id}")]
        public async Task<ApiResponse<CreateProductViewModel>> UpdateProduct(CreateProductViewModel createProductViewModel,string id) => await _productService.UpdateProduct(createProductViewModel,id);
    }
}
