using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.SkinTypeViewModels
{
    public class SkinConditionFilterModel
    {
        public string? SkinConditionName { get; set; }
        public string? Description { get; set; }
        public bool? IsDeleted { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
