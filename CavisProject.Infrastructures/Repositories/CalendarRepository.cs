using CavisProject.Application.Interfaces;
using CavisProject.Application.Repositories;
using CavisProject.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Infrastructures.Repositories
{
    public class CalendarRepository : GenericRepository<Calendar>, ICalendarRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;
        public CalendarRepository(
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
      
        public async Task<List<Guid>> GetUnAvailableCalendarAsync(DateTime? date)
        {
            return await _dbContext.CalendarDetails
                .Where(c => c.AvailabilityDate.Value.Date == date.Value.Date).Select(cd=>cd.CalendarId)
                .ToListAsync();
        }
    }
}