using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.Services;
using CavisProject.Application.ViewModels.ProductCategoryViewModel;
using CavisProject.Application.ViewModels.ProductViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CavisProject.API.Controllers
{ [Route("api/v1/product")]
    public class ProductController : ControllerBase 
       
    {
     
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("{id}")]
        public async Task<ApiResponse<ProductViewModel>> GetProductDetailById(string id) =>
            await _productService.GetProductDetailByIdAsync(id);
        /*[HttpPost("")]
        public async Task<ApiResponse<CreateProductViewModel>> CreateProductCategory([FromBody] CreateProductViewModel createProductViewModel)
       => await _productService.CreateProduct(createProductViewModel);*/
    }
}
