using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.ProductViewModel
{
    public class CreateProductViewModel
    {
        public string? ProductName { get; set; }
  
        public double ClickMoney { get; set; }

        public string? Description { get; set; }
        public string? URL { get; set; }
        public Guid? SupplierId { get; set; }
        public Guid? ProductCategoryId { get; set; }
        public List<Guid>? SkinId { get; set; }
        public int Status { get; set; }
    }
}
