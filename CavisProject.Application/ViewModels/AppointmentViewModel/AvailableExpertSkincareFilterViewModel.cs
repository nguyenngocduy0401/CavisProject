using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.AppointmentViewModel
{
    public class AvailableExpertSkincareFilterViewModel
    {
        public string? Date { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; }=10;
    }
}
