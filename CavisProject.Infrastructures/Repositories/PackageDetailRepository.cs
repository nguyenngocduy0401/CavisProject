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
    public class PackageDetailRepository :IPackageDetailRepository
    {
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;
        private readonly AppDbContext _dbContext;
        public PackageDetailRepository(ICurrentTime timeService, IClaimsService claimsService, AppDbContext dbContext)
        {
            _timeService = timeService;
            _claimsService = claimsService;
            _dbContext = dbContext;
        }

        public async Task AddAsync(PackageDetail packageDetail)
        {
        
            await _dbContext.AddAsync(packageDetail);
        }
        public async Task<PackageDetail> GetByUserIdAsync(string userId)
        {
            return await _dbContext.PackageDetails
                .FirstOrDefaultAsync(pd => pd.UserId == userId);
        }
        public async Task<List<PackageDetail>> GetAllAsync()
        {
            return await _dbContext.PackageDetails.ToListAsync();
        }
        public async Task<int> GetTotalUsersByPackageIdAsync(Guid packageId)
        {
            var packageDetails = await _dbContext.PackageDetails
                                                .Where(pd => pd.PackagePremiumId == packageId && pd.Status==1)
                                                .ToListAsync();
            return packageDetails.Count;
        }
        public async Task<PackageDetail?> FindAsync(Expression<Func<PackageDetail, bool>> predicate)
        {
            return await _dbContext.Set<PackageDetail>().FirstOrDefaultAsync(predicate);
        }
        public void Update(PackageDetail packageDetail)
        {
            _dbContext.Entry(packageDetail).State = EntityState.Modified;
        }
    }
}
