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
        Task<ApiResponse<CreateSupplierViewModel>> CreateSupplier(CreateSupplierViewModel  createSupplierViewModel);
        Task<ApiResponse<CreateSupplierViewModel>> UppdateSupplier(CreateSupplierViewModel updateSupplierViewModel, string id);
        Task<ApiResponse<bool>> DeleteSupplier(string id);
        Task<ApiResponse<Pagination<SupplierViewModel>>> FilterSupplier(FilterSupplierViewModel filterSupplierViewModel);
    }
}
