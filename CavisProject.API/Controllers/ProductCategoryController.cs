using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.Repositories;
using CavisProject.Application.ViewModels.ProductCategoryViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CavisProject.API.Controllers
{
    public class ProductCategoryController
    {
        public readonly IProductCategoryService _productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }
        [HttpPost("create-product-category")]
        public async Task<ApiResponse<CreateProductCategoryViewModel>> CreateProductCategory(CreateProductCategoryViewModel createProductCategoryViewModel) => await _productCategoryService.CreateProductCategory(createProductCategoryViewModel);
        [HttpDelete("get-product-category")]
        public async Task<ApiResponse<bool>> DeleteProductCategory(string id) => await _productCategoryService.DeleteProductCategory(id);
        [HttpPut("update-product-category")]
        public async Task<ApiResponse<CreateProductCategoryViewModel>> UpdateProductCategory(CreateProductCategoryViewModel createProductCategoryViewModel, string id) => await _productCategoryService.UppdateProductCategory(createProductCategoryViewModel, id);
    }
}
