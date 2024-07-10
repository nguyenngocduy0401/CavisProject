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
        Task<List<CalendarDetail>> GetAvailableExpertsAsync(string? date, string? startTime, string? endTime);
        Task<bool> CheckAvailabilityAsync(string expertId, DateTime date, TimeSpan startTime, TimeSpan endTime);
        Task<List<CalendarDetail>> GetAllCalendarDetailsAsync();
        Task AddAsync(CalendarDetail calendarDetail);
        Task<CalendarDetail> GetByIdAsync(Guid calendarId, string userId);
        Task UpdateAsync(CalendarDetail calendarDetail);
        Task<bool> ExistsAsync(string userId, Guid calendarId, DateTime availabilityDate);
        Task AddOrUpdateCalendarDetailsAsync(IEnumerable<CalendarDetail> calendarDetails);
        Task<CalendarDetail> GetByCalendarIdAndAvailabilityDateAsync(Guid calendarId, DateTime availabilityDate);

    }
}
