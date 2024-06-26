﻿using CavisProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.MethodViewModels
{
    public class MethodViewModel
    {
        public string? Id { get; set; }
        public string? MethodName { get; set; }
        public string? Description { get; set; }
        public string? URLImage { get; set; }
        public string? FullName { get; set; }
         
        public MethodCategoryEnum? Category { get; set; }
        public string? UserAvatar { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
