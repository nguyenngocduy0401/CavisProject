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
        Task<ApiResponse<CreateProductCategoryViewModel>> CreateProductCategory(CreateProductCategoryViewModel createProductCategoryViewModel);
        Task<ApiResponse<CreateProductCategoryViewModel>> UppdateProductCategory(CreateProductCategoryViewModel UpdateProductCategoryViewModel,string id);
        Task<ApiResponse<Pagination<ProductCategoryViewModel>>> FilterProductCategory(FilterProductCategoryModel filterProductCategory);
        Task<ApiResponse<bool>> DeleteProductCategory(string id);

    }
}
