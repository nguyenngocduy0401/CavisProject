using CavisProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Repositories
{
    public interface ISkinTypeRepository:IGenericRepository<Skin>
    {
        Task<Skin> GetFirstOrDefaultAsync(Expression<Func<Skin, bool>> filter, string includeProperties = "");
    }
}
