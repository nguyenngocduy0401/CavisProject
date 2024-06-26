using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.PackagePremiumViewModels
{
    public class CreatePackagePremiumViewModel
    {
        public string? PackagePremiumName { get; set; }
        public double Price { get; set; }
        public double Duration { get; set; }
        public string? Description { get; set; }
    }
}
