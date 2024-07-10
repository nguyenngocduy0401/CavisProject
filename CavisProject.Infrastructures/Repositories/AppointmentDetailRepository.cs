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
    public class AppointmentDetailRepository : IAppointmentDetailRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;
        public AppointmentDetailRepository(AppDbContext dbContext, ICurrentTime timeService, IClaimsService claimsService)
        {
            _dbContext = dbContext;
            _timeService = timeService;
            _claimsService = claimsService;
        }
        public async Task AddAsync(AppointmentDetail appointmentDetails)
        {
            await _dbContext.Set<AppointmentDetail>().AddAsync(appointmentDetails);
            await _dbContext.SaveChangesAsync();
        }
      
    }
}
