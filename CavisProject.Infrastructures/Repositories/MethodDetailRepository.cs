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
    public class MethodDetailRepository : IMethodDetailRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<MethodDetail> _dbset;
        public MethodDetailRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbset = dbContext.Set<MethodDetail>();

        }
        public async Task AddAsync(MethodDetail methodDetail)
        {

            await _dbContext.AddAsync(methodDetail);
        }
        public async Task<IEnumerable<MethodDetail>> GetAllAsync(Expression<Func<MethodDetail, bool>> predicate)
        {
            return await _dbset.Where(predicate).ToListAsync();
        }
        public void Update(MethodDetail entity)
        {
            _dbContext.Update(entity);
        }
        public async Task DeleteAsync(MethodDetail methodDetail)
        {
            _dbContext.Remove(methodDetail);
            await _dbContext.SaveChangesAsync();
        }
    }
}
