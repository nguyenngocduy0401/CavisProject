using CavisProject.Domain.Entity;
using CavisProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.MethodViewModels
{
    public class FilterSuggestMethodModel
    {
        public MethodCategoryEnum Category { get; set; }
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 10;
    }
}
