using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.SkinTypeViewModel
{
    public class SkinFilterModel
    {
        public string? SkinTypeName { get; set; }
        public string? Description { get; set; }
       // public bool Category { get; set; } = true;
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
