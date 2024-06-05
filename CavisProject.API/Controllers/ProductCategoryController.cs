using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.Repositories;
using CavisProject.Application.ViewModels.ProductCategoryViewModel;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("")]
        public async Task<ApiResponse<CreateProductCategoryViewModel>> CreateProductCategory(CreateProductCategoryViewModel createProductCategoryViewModel)
        => await _productCategoryService.CreateProductCategory(createProductCategoryViewModel);
        

        [HttpDelete("{id}")]
        public async Task<ApiResponse<bool>> DeleteProductCategory(string id)
        => await _productCategoryService.DeleteProductCategory(id);
        

        [HttpPut("{id}")]
        public async Task<ApiResponse<CreateProductCategoryViewModel>> UpdateProductCategory([FromBody] CreateProductCategoryViewModel createProductCategoryViewModel, [FromRoute] string id)
       =>  await _productCategoryService.UppdateProductCategory(createProductCategoryViewModel, id);
        

        [HttpGet("")]
        public async Task<ApiResponse<Pagination<CreateProductCategoryViewModel>>> FilterProductCategory(FilterProductCategory filterProductCategory)
       => await _productCategoryService.FilterProductCategory(filterProductCategory);
        
    }
}
