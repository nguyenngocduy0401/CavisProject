using CavisProject.Application.Commons;
using CavisProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Repositories
{
    public interface IPersonalAnalystRepository :IGenericRepository<PersonalAnalyst>
    {
        Task<List<Guid?>> GetSkinIdsByPersonalAnalystIdAsync(string personalAnalystId);
        Task<Guid> CreatePersonalAnalystAsync(PersonalAnalyst personalAnalyst);
        Task<PersonalAnalyst> GetLastPersonalAnalystAsync();
        Task<Pagination<Product>> SuggestProductAsync(Guid personalAnalystId, int? pageIndex = null, int? pageSize = null);
        Task<bool> CheckExistPersonalAnalystAsync(string userId);
    }
}
