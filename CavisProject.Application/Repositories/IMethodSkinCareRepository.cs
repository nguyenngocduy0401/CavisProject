using CavisProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Repositories
{
    public interface IMethodSkinCareRepository :IGenericRepository<Method>
    {
        Task<Method> GetFirstOrDefaultAsync(Expression<Func<Method, bool>> filter, string includeProperties = "");
        Task<Method> GetMethodByIdAsync(Guid methodId);
    }
}
