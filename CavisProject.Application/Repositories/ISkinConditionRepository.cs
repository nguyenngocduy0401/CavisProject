using CavisProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Repositories
{
    public interface ISkinConditionRepository: IGenericRepository<Skin>
    {
        Task<List<Skin>>  GetAllSkinConditionAsync();
    }
}
