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
        Task<ApiResponse<CreateProductViewModel>> CreateProduct(CreateProductViewModel createProductViewModel);
        Task<ApiResponse<Pagination<CreateProductViewModel>>> Filter(FilterProductViewModel filterProductViewModel);
        Task<ApiResponse<bool>> DeleteProduct(string id);
        Task<ApiResponse<CreateProductViewModel>> GetProductDetail(string id);
    }
}

