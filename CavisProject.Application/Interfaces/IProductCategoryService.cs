using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.ProductCategoryViewModel;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Interfaces
{
    public interface IProductCategoryService
    {
        Task<ApiResponse<bool>> CreateProductCategoryAsync(CreateProductCategoryViewModel createProductCategoryViewModel);
        Task<ApiResponse<bool>> UpdateProductCategoryAsync(CreateProductCategoryViewModel updateProductCategoryViewModel, string id);
        Task<ApiResponse<Pagination<ProductCategoryViewModel>>> FilterProductCategoryAsync(FilterProductCategoryModel filterProductCategory);
        Task<ApiResponse<bool>> DeleteProductCategoryAsync(string id);
        Task<ApiResponse<ProductCategoryViewModel>> GetProductCategoryByIdAsync(string id);


    }
}
