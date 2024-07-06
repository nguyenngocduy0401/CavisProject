using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.AppointmentViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Interfaces
{
    public interface IAppointmentService
    {
        Task<ApiResponse<List<ExpertAvailabilityViewModel>>> GetAvailableExpertsAsync(DateTime Date, TimeSpan StartTime, TimeSpan EndTime);
        Task<ApiResponse<List<AppointmentViewModel>>> GetWeeklyScheduleAsync(DateTime StartDate, DateTime EndDate);
    }
}
