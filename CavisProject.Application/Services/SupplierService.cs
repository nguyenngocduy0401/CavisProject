using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.SupplierViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Services
{
    public class SupplierService : ISupplierService
    {
        public Task<ApiResponse<CreateSupplierViewModel>> CreateSupplier(CreateSupplierViewModel createSupplierViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> DeleteSupplier(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<CreateSupplierViewModel>> GetAllSupplier()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<CreateSupplierViewModel>> UppdateSupplier(CreateSupplierViewModel updateSupplierViewModel, string id)
        {
            throw new NotImplementedException();
        }
    }
}
