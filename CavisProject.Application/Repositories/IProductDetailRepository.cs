using CavisProject.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Repositories
{
    public interface IProductDetailRepository
    {
        Task AddAsync(ProductDetail productDetail);

        void Update(ProductDetail entity);

        Task<IEnumerable<ProductDetail>> GetAllAsync(Expression<Func<ProductDetail, bool>> predicate);
    }
}
