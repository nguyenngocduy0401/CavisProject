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
    public interface IPackageDetailRepository
    {
        Task AddAsync(PackageDetail packageDetail);
        Task<PackageDetail> GetByUserIdAsync(string userId);
        Task<List<PackageDetail>> GetAllAsync();
        Task<int> GetTotalUsersByPackageIdAsync(Guid packageId);
        Task<PackageDetail?> FindAsync(Expression<Func<PackageDetail, bool>> predicate);
        void Update(PackageDetail packageDetail);
        

    }
}
