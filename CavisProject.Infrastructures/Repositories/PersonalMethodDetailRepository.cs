using CavisProject.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Infrastructures.Repositories
{
    public class PersonalMethodDetailRepository : IPersonalMethodDetailRepository
    {
        private readonly AppDbContext _dbContext;
        public PersonalMethodDetailRepository(AppDbContext context) 
        {
            _dbContext = context;
        }
    }
}
