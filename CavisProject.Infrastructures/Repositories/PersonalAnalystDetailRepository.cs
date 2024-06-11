using CavisProject.Application.Repositories;
using CavisProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Infrastructures.Repositories
{
    public class PersonalAnalystDetailRepository : IPersonalAnalystDetailRepository
    {
        private readonly AppDbContext _appDbContext;
        public PersonalAnalystDetailRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddRangeAsync(List<PersonalAnalystDetail> personalAnalystDetails)
        {
            await _appDbContext.AddRangeAsync(personalAnalystDetails);
        }
    }
}
