﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.AppointmentViewModel
{
    public class FilterAppointmentByLoginViewModel
    {
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
