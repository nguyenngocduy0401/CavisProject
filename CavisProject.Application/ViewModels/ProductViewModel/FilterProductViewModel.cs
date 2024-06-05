using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.ProductViewModel
{
    public class FilterProductViewModel
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public Guid? SupplierId { get; set; }
        public Guid? ProductCategoryId { get; set; }

        public Guid? SkinTypeId { get; set; } // Loại Skin là Category = true
        public Guid? SkinConditionID { get; set; } // Loại Skin là Category = false
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
