using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.MethodViewModels
{
    public class FilterMethodSkinCareViewModel
    {
        public string? MethodName { get; set; }
        public string? Description { get; set; }
        public Guid? SkinTypeId { get; set; }
        public Guid? SkinConditionID { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
