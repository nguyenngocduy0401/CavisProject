using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.AppointmentViewModel
{
    public class CreateMakeUpAppointmentViewModel
    {
        public string? Date { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? PhoneNumber { get; set; }
        public string ExpertId { get; set; }
        public string? Email { get; set; }
    }
}
