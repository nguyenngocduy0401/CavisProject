using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.ProductCategoryViewModel;
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
        Task<ApiResponse<bool>> DeleteProductCategory(string id);

    }
}
