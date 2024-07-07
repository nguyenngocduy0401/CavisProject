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
    public class SkincareRoutineRepository : GenericRepository<SkincareRoutine>, ISkincareRoutineRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;
        public SkincareRoutineRepository(
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

        public async Task<bool> CheckExistSkincareRoutine(string userId)
        {
            var skincareRoutine = await _dbSet.Where(e => e.UserId == userId)
                .OrderByDescending(e => e.CreationDate).FirstOrDefaultAsync();
            if (skincareRoutine == null) return false;
            if (DateOnly.FromDateTime(skincareRoutine.CreationDate) != DateOnly.FromDateTime(DateTime.Now)) return false;
            return true;
        }
    }
}
