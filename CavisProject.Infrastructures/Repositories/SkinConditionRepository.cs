using CavisProject.Application.Interfaces;
using CavisProject.Application.Repositories;
using CavisProject.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Infrastructures.Repositories
{
    public class SkinConditionRepository : GenericRepository<Skin>, ISkinConditionRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;
        public SkinConditionRepository(
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
      
        public async Task<List<Skin>> GetAllSkinConditionAsync()
        {
            return await _dbContext.Set<Skin>()
                .Where(sc => sc.Category == false)
                .ToListAsync();
        }
    }
}
