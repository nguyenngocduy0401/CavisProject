using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.AppointmentViewModel
{
    public class AppointmentViewModel
    {
        public Guid? AppointmentId { get; set; }
        public string? Title { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? ExpertId { get; set; }
        public string? UserId { get; set; }
    }
}
