using CavisProject.Application.Interfaces;
using CavisProject.Application.Repositories;
using CavisProject.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CavisProject.Infrastructures.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;
        public AppointmentRepository(
            AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService
        )
            : base(context, timeService, claimsService)
        {
            _dbContext = context;
            _timeService = timeService;
            _claimsService = claimsService;
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
    }
}

