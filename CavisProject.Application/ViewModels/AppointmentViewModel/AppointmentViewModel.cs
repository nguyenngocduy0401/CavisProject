using CavisProject.Application.ViewModels.AppointmentViewModel.UserInfoViewModel;
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
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public ExpertInfoViewModel? ExpertInfo { get; set; }
        public UserInfoViewModel.UserInfoViewModel? UserInfo { get; set; }
    }
}
