using CavisProject.Application;
using CavisProject.Application.Interfaces;
using CavisProject.Application.Repositories;
using CavisProject.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CavisProject.Infrastructures.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;
        private readonly UserManager<User> _userManager;
        public AppointmentRepository(
            AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService,UserManager<User> userManager

        )
            : base(context, timeService, claimsService)
        {
            _dbContext = context;
            _timeService = timeService;
            _claimsService = claimsService;
            _userManager = userManager;
        }

        public async Task<List<Appointment>> GetAppointmentsByDateRangeAsync(DateTime startDate, DateTime endDate, string userId)
        {
            return await _dbSet
           .Where(a => a.Date >= startDate && a.Date <= endDate && a.AppointmentDetails.Any(ad => ad.UserId == userId))
           .Include(a => a.AppointmentDetails)
           .ToListAsync();
        }
       public async Task<List<Appointment>> GetAppointmentsForUserAsync(string userId, DateTime? date, TimeSpan? startTime, TimeSpan? endTime, int pageIndex, int pageSize)
        {
            var query = _dbContext.Appointments               
                .Include(a => a.AppointmentDetails)
                    .ThenInclude(ad => ad.User)
                .Where(a => a.AppointmentDetails.Any(ad => ad.UserId == userId))
                .AsQueryable();

            if (date.HasValue)
            {
                query = query.Where(a => a.Date == date.Value.Date);
            }

            if (startTime.HasValue && endTime.HasValue)
            {
                query = query.Where(a => a.StartTime.Value.TimeOfDay >= startTime.Value && a.EndTime.Value.TimeOfDay <= endTime.Value);
            }
            else if (startTime.HasValue)
            {
                query = query.Where(a => a.StartTime.Value.TimeOfDay >= startTime.Value);
            }
            else if (endTime.HasValue)
            {
                query = query.Where(a => a.EndTime.Value.TimeOfDay <= endTime.Value);
            }

            int totalCount = await query.CountAsync();
            int skip = (pageIndex - 1) * pageSize;
            var appointments = await query.Skip(skip).Take(pageSize)
                .ToListAsync();

            return appointments;
        }
        public async Task<bool> IsExpertAvailable(string expertId, DateTime? date, TimeSpan? startTime, TimeSpan? endTime)
        {

            var appointmentDetails = await _dbContext.AppointmentDetails
          .Where(ad => ad.UserId == expertId)
          .Select(ad => ad.AppointmentId)
          .ToListAsync();

            
            var appointments = await _dbContext.Appointments
                .Where(a => appointmentDetails.Contains(a.Id) && a.Date.Value.Date == date.Value.Date)
                .ToListAsync();

            foreach (var appointment in appointments)
            {
                var appointmentDetail = await _dbContext.AppointmentDetails
                    .FirstOrDefaultAsync(ad => ad.AppointmentId == appointment.Id && ad.UserId == expertId);

                if (appointmentDetail != null && IsTimeOverlap(startTime, endTime, appointment.StartTime.Value.TimeOfDay, appointment.EndTime.Value.TimeOfDay))
                {
                    return false; 
                }
            }

            return true;

        }
        private bool IsTimeOverlap(TimeSpan? start1, TimeSpan? end1, TimeSpan? start2, TimeSpan? end2)
        {
            return start1 < end2 && end1 > start2;
        }
    }
}

