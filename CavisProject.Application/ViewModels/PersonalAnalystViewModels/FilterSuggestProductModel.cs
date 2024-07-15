using CavisProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.PersonalAnalystViewModels
{
    public class FilterSuggestProductModel
    {
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public Guid? CategoryId { get; set; }
        public CompatibleProductsEnum CompatibleProducts { get; set; }
        public ProductStatusEnum Category { get; set; } = ProductStatusEnum.Skincare;
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 10;
    }
}
