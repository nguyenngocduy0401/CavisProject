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
        Task<ApiResponse<Pagination<ExpertAvailabilityViewModel>>> GetAvailableExpertsAsync(AvailableExpertSkincareFilterViewModel filter);
        Task<ApiResponse<Pagination<AppointmentViewModel>>> GetWeeklyScheduleAsync(AvailableExpertSkincareFilterViewModel filter);
        Task<ApiResponse<bool>> BookAppointmentAsync(CreateAppointmentViewModel create);
    }
}
