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
        Task<ApiResponse<bool>> CreateProduct(CreateProductViewModel createProductViewModel);
        Task<ApiResponse<Pagination<ProductViewModel>>> Filter(FilterProductViewModel filterProductViewModel);
        Task<ApiResponse<bool>> DeleteProduct(string id);
        Task<ApiResponse<CreateProductViewModel>> UpdateProduct(CreateProductViewModel createProductViewModel, string id);
    }
}

