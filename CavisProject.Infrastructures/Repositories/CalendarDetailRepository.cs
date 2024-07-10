using CavisProject.Application;
using CavisProject.Application.Interfaces;
using CavisProject.Application.Repositories;
using CavisProject.Domain.Entity;
using CavisProject.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CavisProject.Infrastructures.Repositories
{
    public class CalendarDetailRepository : ICalendarDetailRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;
        public CalendarDetailRepository(AppDbContext dbContext, ICurrentTime timeService, IClaimsService claimsService)
        {
            _dbContext = dbContext;
            _timeService = timeService;
            _claimsService = claimsService;
        }

        public async Task<List<CalendarDetail>> GetByUserIdAsync(string userId)
        {
            return await _dbContext.Set<CalendarDetail>()
                           .Where(cd => cd.UserId == userId)
                           .ToListAsync();
        }
        public async Task<List<CalendarDetail>> GetAvailableExpertsAsync(string? date, string? startTime, string? endTime)
        {

            DateTime? availabilityDate = null;
            TimeSpan? start = null;
            TimeSpan? end = null;
            if (!string.IsNullOrEmpty(date))
            {
                availabilityDate = DateTime.Parse(date);
            }

            if (!string.IsNullOrEmpty(startTime))
            {
                start = TimeSpan.Parse(startTime);
            }

            if (!string.IsNullOrEmpty(endTime))
            {
                end = TimeSpan.Parse(endTime);
            }
            var query = _dbContext.CalendarDetails
                .Include(cd => cd.User)
                .Include(cd => cd.Calendar)
                .Where(cd => cd.Status == CalendarStatusEnum.Available);

            if (availabilityDate.HasValue)
            {
                query = query.Where(cd => cd.AvailabilityDate.HasValue && cd.AvailabilityDate.Value.Date == availabilityDate.Value.Date);
            }

            if (start.HasValue && end.HasValue)
            {
                query = query.Where(cd => cd.Calendar.StartTime == start.Value && cd.Calendar.EndTime == end.Value);
            }
            else if (start.HasValue)
            {
                query = query.Where(cd => cd.Calendar.StartTime == start.Value);
            }
            else if (end.HasValue)
            {
                query = query.Where(cd => cd.Calendar.EndTime == end.Value);
            }
            var availableCalendarDetails = await query.ToListAsync();

            return availableCalendarDetails;
        }

        public async Task<List<CalendarDetail>> GetAllCalendarDetailsAsync()
        {
            var availableCalendarDetails = await _dbContext.CalendarDetails
        .Include(cd => cd.User)
        .Include(cd => cd.Calendar)
        .Where(cd => cd.Status == CalendarStatusEnum.Available) 
        .ToListAsync();

            return availableCalendarDetails;
        }
       
        public async Task<bool> ExistsAsync(string userId, Guid calendarId, DateTime availabilityDate)
        {
            return await _dbContext.CalendarDetails.AnyAsync(cd => cd.UserId == userId && cd.CalendarId == calendarId && cd.AvailabilityDate == availabilityDate);
        }

        public async Task AddOrUpdateCalendarDetailsAsync(IEnumerable<CalendarDetail> calendarDetails)
        {
            foreach (var detail in calendarDetails)
            {
                var existingEntity = _dbContext.ChangeTracker.Entries<CalendarDetail>()
                    .FirstOrDefault(e => e.Entity.UserId == detail.UserId && e.Entity.CalendarId == detail.CalendarId);

                if (existingEntity == null)
                    { 
                    if (detail.CalendarId == Guid.Empty)
                    {
                        await _dbContext.CalendarDetails.AddAsync(detail);
                    }
                    else
                    {
                        _dbContext.CalendarDetails.Attach(detail);
                        _dbContext.Entry(detail).State = EntityState.Modified;
                    }
                }
            }

            await _dbContext.SaveChangesAsync();
        }

    

    public async Task DeleteRangeAsync(IEnumerable<CalendarDetail> calendarDetails)
        {
            _dbContext.Set<CalendarDetail>().RemoveRange(calendarDetails);
            await _dbContext.SaveChangesAsync();
        }
        public async Task AddRangeAsync(IEnumerable<CalendarDetail> calendarDetails)
        {
            await _dbContext.Set<CalendarDetail>().AddRangeAsync(calendarDetails);
            await _dbContext.SaveChangesAsync();
        }
        public async Task AddAsync(CalendarDetail calendarDetail)
        {
            await _dbContext.CalendarDetails.AddAsync(calendarDetail);
        }
        public async Task UpdateAsync(CalendarDetail calendarDetail)
        {
            _dbContext.CalendarDetails.Update(calendarDetail);
            await _dbContext.SaveChangesAsync();


        }
        public async Task<CalendarDetail> GetByCalendarIdAndAvailabilityDateAsync(Guid calendarId, DateTime availabilityDate, string userId)
        {
            return await _dbContext.CalendarDetails
                .FirstOrDefaultAsync(cd => cd.CalendarId == calendarId &&
                                            cd.AvailabilityDate == availabilityDate &&
                                            cd.UserId == userId);
        }
        public async Task<CalendarDetail> GetByIdAsync(Guid calendarId, string userId)
        {
            return await _dbContext.CalendarDetails
                .FirstOrDefaultAsync(cd => cd.CalendarId == calendarId && cd.UserId == userId);
        }
    
        public async Task<bool> CheckAvailabilityAsync(string expertId, DateTime date, TimeSpan startTime, TimeSpan endTime)
        {
            var startDateTime = date.Date + startTime;
            var endDateTime = date.Date + endTime;

            // Check if there is any overlapping appointment in AppointmentDetail
            var hasConflict = await _dbContext.Set<AppointmentDetail>()
                .Include(ad => ad.Appointment)
                .AnyAsync(ad => ad.UserId == expertId &&
                                ad.Appointment.Date == date &&
                                ((ad.Appointment.StartTime.HasValue && ad.Appointment.StartTime.Value.TimeOfDay <= startTime && ad.Appointment.EndTime.HasValue && ad.Appointment.EndTime.Value.TimeOfDay > startTime) ||
                                 (ad.Appointment.StartTime.HasValue && ad.Appointment.StartTime.Value.TimeOfDay < endTime && ad.Appointment.EndTime.HasValue && ad.Appointment.EndTime.Value.TimeOfDay >= endTime) ||
                                 (ad.Appointment.StartTime.HasValue && ad.Appointment.StartTime.Value.TimeOfDay >= startTime && ad.Appointment.EndTime.HasValue && ad.Appointment.EndTime.Value.TimeOfDay <= endTime)));

            return !hasConflict;
        }
        public async Task<CalendarDetail> GetByCalendarIdAndAvailabilityDateAsync(Guid calendarId, DateTime availabilityDate)
        {
            return await _dbContext.CalendarDetails
                .FirstOrDefaultAsync(cd => cd.CalendarId == calendarId && cd.AvailabilityDate == availabilityDate);
        }
    }
}
