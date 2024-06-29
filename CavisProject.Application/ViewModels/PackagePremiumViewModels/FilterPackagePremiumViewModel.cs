using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.PackagePremiumViewModels
{
    public class FilterPackagePremiumViewModel
    {
        public string? PackagePremiumName { get; set; }
        public double Price { get; set; }
        public double Duration { get; set; }
        public bool? IsDeleted { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
