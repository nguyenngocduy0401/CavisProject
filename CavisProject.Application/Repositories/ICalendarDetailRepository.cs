using CavisProject.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Repositories
{
    public interface ICalendarDetailRepository
    {
        Task<List<CalendarDetail>> GetByUserIdAsync(string userId);
        Task DeleteRangeAsync(IEnumerable<CalendarDetail> calendarDetails);
        Task AddRangeAsync(IEnumerable<CalendarDetail> calendarDetails);
        Task<List<CalendarDetail>> GetAvailableExpertsAsync(DateTime date, TimeSpan startTime, TimeSpan endTime);

    }
}
