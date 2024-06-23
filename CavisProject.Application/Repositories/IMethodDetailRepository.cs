using CavisProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Repositories
{
    public interface IMethodDetailRepository 
    {
        Task AddAsync(MethodDetail methodDetail);
        void Update(MethodDetail entity);
        Task<IEnumerable<MethodDetail>> GetAllAsync(Expression<Func<MethodDetail, bool>> predicate);
    }
}
