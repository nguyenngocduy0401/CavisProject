using CavisProject.Application.Repositories;
using CavisProject.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Infrastructures.Repositories
{
    public class ProductDetailRepository : IProductDetailRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<ProductDetail> _dbset;
        public ProductDetailRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbset = dbContext.Set<ProductDetail>();

        }
        public async Task AddAsync(ProductDetail productDetail)
        {

            await _dbContext.AddAsync(productDetail);
        }
        
        public void Update(ProductDetail entity)
        {
            _dbContext.Update(entity);
        }
        public async Task<IEnumerable<ProductDetail>> GetAllAsync(Expression<Func<ProductDetail, bool>> predicate)
        {
            return await _dbset.Where(predicate).ToListAsync();
        }

        public async Task Delete(ProductDetail productDetail)
        {
            _dbContext.Remove(productDetail);
            await _dbContext.SaveChangesAsync();
        }
    }
}
