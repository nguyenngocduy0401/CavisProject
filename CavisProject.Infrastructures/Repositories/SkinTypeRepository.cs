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
    public class SkinTypeRepository : GenericRepository<SkinType>, ISkinTypeRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;
        public SkinTypeRepository(
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
        public async Task<List<SkinType>> GetAllWithCategoryFalseAsync()
        {
            return await _dbContext.SkinTypes.Where(s => !s.Category).ToListAsync();
        }

        public async Task<List<SkinType>> GetAllWithCategoryTrueAsync()
        {
            return await _dbContext.SkinTypes.Where(s => s.Category).ToListAsync();
        }
    }
}
