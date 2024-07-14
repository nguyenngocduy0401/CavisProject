using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.Calendar
{
    public class CalendarViewModel
    {
        public Guid Id { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
       // public double? Duration { get; set; }
    }
}
