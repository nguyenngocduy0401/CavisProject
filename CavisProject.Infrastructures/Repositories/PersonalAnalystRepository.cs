using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.Repositories;
using CavisProject.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CavisProject.Infrastructures.Repositories
{
    public class PersonalAnalystRepository : GenericRepository<PersonalAnalyst>, IPersonalAnalystRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;
        public PersonalAnalystRepository(
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
        public async Task<Pagination<Product>> SuggestProductAsync(Guid personalAnalystId, int? pageIndex = null, int? pageSize = null)
        {
            var skinIds = await _dbContext.PersonalAnalystDetails
                .Where(e => e.PersonalAnalystId == personalAnalystId)
                .Select(e => e.SkinId)
                .Distinct()
                .ToListAsync();

            var productsQuery = _dbContext.Products
                .Include(e => e.ProductDetails)
                .ThenInclude(e => e.Skins)
                .Where(e =>
                    e.ProductDetails.Any(pd => skinIds.Contains(pd.SkinId) && pd.Skins.Category)
                // Contains Skin with Category = true
                /* &&e.ProductDetails.Any(pd => skinIds.Contains(pd.SkinId) && !pd.Skins.Category)  // Contains Skin with Category = false*/
                );

            var itemCount = await productsQuery.CountAsync();

            if (pageIndex.HasValue && pageSize.HasValue)
            {
                int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
                int validPageSize = pageSize.Value > 0 ? pageSize.Value : 10;

                productsQuery = productsQuery.Skip(validPageIndex * validPageSize).Take(validPageSize);
            }


            var pagination = new Pagination<Product>()
            {
                PageIndex = pageIndex ?? 0,
                PageSize = pageSize ?? 10,
                TotalItemsCount = itemCount,
                Items = await productsQuery.ToListAsync()
        };

            return pagination;
        }
        public async Task<Guid> CreatePersonalAnalystAsync(PersonalAnalyst personalAnalyst)
        {
            personalAnalyst.CreationDate = _timeService.GetCurrentTime();
            personalAnalyst.StartDate = _timeService.GetCurrentTime();
            personalAnalyst.CreatedBy = _claimsService.GetCurrentUserId;
            var result = await _dbSet.AddAsync(personalAnalyst);
            return result.Entity.Id;
        }

        public async Task<PersonalAnalyst> GetLastPersonalAnalystAsync()
        {
            var userId = _claimsService.GetCurrentUserId.ToString();
            var personalAnalyst = await _dbContext.PersonalAnalysts
            .Where(e => e.UserId == userId)
            .OrderByDescending(e => e.StartDate)
            .FirstOrDefaultAsync();
            if (personalAnalyst == null) throw new Exception();
            return personalAnalyst;
        }

        public async Task<List<Guid?>> GetSkinIdsByPersonalAnalystIdAsync(string personalAnalystId)
        {
            // Thực hiện truy vấn để lấy các skinId của personalAnalystId từ cơ sở dữ liệu
            var skinIds = await _dbContext.PersonalAnalystDetails
                                        .Where(pad => pad.PersonalAnalystId == Guid.Parse(personalAnalystId))
                                        .Select(pad => pad.SkinId)
                                        .Distinct()
                                        .ToListAsync();

            return skinIds;
        }
    }
}
