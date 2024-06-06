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
