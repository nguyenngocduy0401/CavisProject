using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.ProductCategoryViewModel;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Application.ViewModels.SupplierViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Interfaces
{
    public interface ISupplierService
    {
        Task<ApiResponse<bool>> CreateSupplierAsync(CreateSupplierViewModel  createSupplierViewModel);
        Task<ApiResponse<bool>> UpdateSupplierAsync(CreateSupplierViewModel updateSupplierViewModel, string id);
        Task<ApiResponse<bool>> DeleteSupplierAsync(string id);
        Task<ApiResponse<Pagination<SupplierViewModel>>> FilterSupplierAsync(FilterSupplierViewModel filterSupplierViewModel);
        Task<ApiResponse<CreateSupplierViewModel>> GetSupplierByIdAsync(string id);
    }
}
