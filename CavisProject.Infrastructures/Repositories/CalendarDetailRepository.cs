using CavisProject.Application.Interfaces;
using CavisProject.Application.Repositories;
using CavisProject.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<List<CalendarDetail>> GetAvailableExpertsAsync(DateTime date, TimeSpan startTime, TimeSpan endTime)
        {
            return await _dbContext.Set<CalendarDetail>()
                .Where(cd => cd.AvailabilityDate.Value.Date == date.Date &&
                             cd.Calendar.StartTime <= startTime &&
                             cd.Calendar.EndTime >= endTime)
                .Include(cd => cd.User) // Bao gồm thông tin người dùng
                .ToListAsync();
        }
    }
}
