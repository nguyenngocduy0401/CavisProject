﻿using CavisProject.Application.Interfaces;
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
    }
}
