using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.PackagePremium
{
    public class PackagePremiumViewModel
    {
        public Guid Id { get; set; }
        public string? PackagePremiumName { get; set; }
        public double Price { get; set; }
        public double Duration { get; set; }
        public string? Description { get; set; }
        public int TotalUsers { get; set; } 

       
        public PackagePremiumViewModel()
        {
            TotalUsers = 0;
        }
    }
}
