﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.ProductViewModel
{
    public class FilterProductViewModel
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public Guid? SupplierId { get; set; }
        public Guid? ProductCategoryId { get; set; }
        public List<Guid>? SkinIds { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
