using CavisProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsBySkinIdAsync(Guid skinId);
        Task<Product> GetFirstOrDefaultAsync(Expression<Func<Product, bool>> filter, string includeProperties = "");
    }
}
