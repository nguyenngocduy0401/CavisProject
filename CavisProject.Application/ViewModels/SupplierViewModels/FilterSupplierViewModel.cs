using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.SupplierViewModel
{
    public class FilterSupplierViewModel
    {
        public string? SupplierName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? Status { get; set; }
        public string? Address { get; set; }
        public bool? IsDeleted { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
