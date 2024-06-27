using CavisProject.Application.Commons;
using CavisProject.Domain.Entity;
using CavisProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Repositories
{
    public interface IPersonalAnalystRepository :IGenericRepository<PersonalAnalyst>
    {
        Task<List<Guid?>> GetSkinIdsByPersonalAnalystIdAsync(string personalAnalystId);
        Task<Guid> CreatePersonalAnalystAsync(PersonalAnalyst personalAnalyst);
        Task<PersonalAnalyst> GetLastPersonalAnalystAsync();
        Task<Pagination<Product>> SuggestProductAsync(Guid personalAnalystId,
        CompatibleProductsEnum compatibleProductsEnum,
        int? pageIndex = null,
        int? pageSize = null,
        Expression<Func<Product, bool>>? filter = null,
        Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null,
        string includeProperties = "",
        string? foreignKey = null,
        object? foreignKeyId = null);
        Task<bool> CheckExistPersonalAnalystAsync(string userId);
        Task<Pagination<Method>> SuggestMethodAsync(Guid personalAnalystId, int? pageIndex = null, int? pageSize = null);
    }
}
