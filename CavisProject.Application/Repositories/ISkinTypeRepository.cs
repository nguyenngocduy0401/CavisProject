using CavisProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Repositories
{
    public interface ISkinTypeRepository:IGenericRepository<SkinType>
    {
        Task<List<SkinType>> GetAllWithCategoryTrueAsync();
        Task<List<SkinType>> GetAllWithCategoryFalseAsync();

    }
}
