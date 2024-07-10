using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.AppointmentViewModel
{
    public class ExpertAvailabilityViewModel
    {
        public string? ExpertId { get; set; }
        public string? ExpertName { get; set; }
        public string? Email { get; set; }
        public string? URLImage { get; set; }
        public DateTime Date { get; set; } 
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; } 
    }
}

