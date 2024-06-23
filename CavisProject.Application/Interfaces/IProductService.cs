using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Interfaces
{
    public interface IProductService
    {
        Task<ApiResponse<ProductViewModel>> GetProductDetailByIdAsync(string productId);
        Task<ApiResponse<bool>> CreateProductAsync(CreateProductViewModel createProductViewModel);
        Task<ApiResponse<Pagination<ProductViewModel>>> FilterProductAsync(FilterProductViewModel filterProductViewModel);
        Task<ApiResponse<bool>> DeleteProductAsync(string id);
        Task<ApiResponse<bool>> UpdateProductAsync(CreateProductViewModel updateProductViewModel, string id);
    }
}

