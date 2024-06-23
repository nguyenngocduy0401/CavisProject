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
    public class SkinTypeRepository : GenericRepository<Skin>, ISkinTypeRepository
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
        public async Task<List<Skin>> GetAllWithCategoryFalseAsync()
        {
            return await _dbContext.Skins.Where(s => !s.Category).ToListAsync();
        }

        public async Task<List<Skin>> GetAllWithCategoryTrueAsync()
        {
            return await _dbContext.Skins.Where(s => s.Category).ToListAsync();
        }
        public async Task<Skin> GetFirstOrDefaultAsync(Expression<Func<Skin, bool>> filter, string includeProperties = "")
        {
            IQueryable<Skin> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}
