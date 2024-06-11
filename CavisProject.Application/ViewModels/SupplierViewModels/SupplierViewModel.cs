using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.SupplierViewModel
{
    public class SupplierViewModel
    {
        public Guid Id { get; set; }
            public string? SupplierName { get; set; }
            public string? PhoneNumber { get; set; }
            public string? Email { get; set; }
            public int Status { get; set; }
            public string? Address { get; set; }
        
    }
}
