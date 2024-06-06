using CavisProject.Application.Commons;
using CavisProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression, string includeProperties = "");
        Pagination<TEntity> GetFilter(
           Expression<Func<TEntity, bool>>? filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
           string includeProperties = "",
           int? pageIndex = null,
           int? pageSize = null,
           string? foreignKey = null,
           object? foreignKeyId = null);

        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(List<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(List<TEntity> entities);
        void SoftRemove(TEntity entity);
        void SoftRemoveRange(List<TEntity> entities);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
  /*      Task<Pagination<TEntity>> ToPagination(int pageNumber = 0, int pageSize = 10);
        Task<Pagination<TEntity>> ToPaginationIsNotDelete(int pageNumber = 0, int pageSize = 10);*/
        /* Task<List<TEntity>> GetAllIsNotDeleteAsync();*/
    }
}
