using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.ProductViewModel
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string? ProductName { get; set; }
        public int ClicksAmount { get; set; }
        public double ClickMoney { get; set; }
        public double TotalMoney { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public string? URLImage { get; set; }
        public string? URL { get; set; }
    }
}
