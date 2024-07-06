using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.Calendar;
using CavisProject.Application.ViewModels.CalendarViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Interfaces
{
    public interface ICalendarService
    {
        Task<ApiResponse<Pagination<CalendarViewModel>>> FilterCalendarAsync(CalendarFilterModel filterModel);
        Task<ApiResponse<CalendarViewModel>> GetCalendarByIdAsync(string id);
        Task<ApiResponse<bool>> SetAvailabilityAsync(string userId, List<CalendarDetailViewModel> availabilities);
    }
}
