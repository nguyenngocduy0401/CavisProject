using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.Repositories;
using CavisProject.Domain.Entity;
using CavisProject.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CavisProject.Infrastructures.Repositories
{
    public class PersonalAnalystRepository : GenericRepository<PersonalAnalyst>, IPersonalAnalystRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;
        public PersonalAnalystRepository(
            AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService
        )
            : base(context, timeService, claimsService)
        {
            _dbContext = context;
            _timeService = timeService;
            _claimsService = claimsService;
        }
        public async Task<Pagination<Product>> SuggestProductAsync(
        Guid personalAnalystId,
        CompatibleProductsEnum compatibleProductsEnum,
        int? pageIndex = null,
        int? pageSize = null,
        Expression<Func<Product, bool>>? filter = null,
        Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null,
        string includeProperties = "",
        string? foreignKey = null,
        object? foreignKeyId = null
        )
        {
            // Lấy danh sách SkinId từ PersonalAnalystDetails
            var skinIds = await _dbContext.PersonalAnalystDetails
                .Where(e => e.PersonalAnalystId == personalAnalystId)
                .Select(e => e.SkinId)
                .Distinct()
                .ToListAsync();

            IQueryable<Product> query = _dbContext.Products;
            if (!string.IsNullOrEmpty(foreignKey) && foreignKeyId != null)
            {
                if (foreignKeyId is Guid guidValue)
                {
                    query = query.Where(e => e.ProductCategoryId == guidValue);
                }
                else if (foreignKeyId is string stringValue)
                {
                    query = query.Where(e => EF.Property<string>(e, foreignKey) == stringValue);
                }
                else
                {
                    throw new ArgumentException("Unsupported foreign key type");
                }
            }
            switch (compatibleProductsEnum)
            {
                case CompatibleProductsEnum.Low:
                    query = query.Include(e => e.ProductDetails)
                        .ThenInclude(e => e.Skins)
                        .Where(e =>
                            e.ProductDetails.Any(pd => skinIds.Contains(pd.SkinId) && pd.Skins.Category)
                        // Contains Skin with Category = true
                        /* &&e.ProductDetails.Any(pd => skinIds.Contains(pd.SkinId) && !pd.Skins.Category)  // Contains Skin with Category = false*/
                        );
                    break;
                case CompatibleProductsEnum.Medium:
                    query = query.Include(e => e.ProductDetails)
                        .ThenInclude(e => e.Skins)
                        .Where(e =>
                            e.ProductDetails.Any(pd => skinIds.Contains(pd.SkinId) && pd.Skins.Category)// Contains Skin with Category = true
                         && e.ProductDetails.Count(pd => skinIds.Contains(pd.SkinId) && !pd.Skins.Category) >=1 // Contains Skin with Category = false
                        );
                    break;
                case CompatibleProductsEnum.High:
                    query = query.Include(e => e.ProductDetails)
                        .ThenInclude(e => e.Skins)
                        .Where(e =>
                            e.ProductDetails.Any(pd => skinIds.Contains(pd.SkinId) && pd.Skins.Category)// Contains Skin with Category = true
                         && e.ProductDetails.Count(pd => skinIds.Contains(pd.SkinId) && !pd.Skins.Category) >= 2  // Contains Skin with Category = false
                        );
                    break;
                case CompatibleProductsEnum.Extremely:
                    // Lấy danh sách các Category = true và số lượng sản phẩm tương ứng với mỗi Category
                    var categories = await _dbContext.ProductDetails
                        .Where(pd => skinIds.Contains(pd.SkinId) && pd.Skins.Category)
                        .Select(pd => pd.ProductId)
                        .Distinct()
                        .ToListAsync();

                    // Danh sách chứa các sản phẩm đã lấy
                    var selectedProductIds = new List<Guid>();

                    // Lặp qua từng Category = true
                    foreach (var categoryProductId in categories)
                    {
                        // Lấy sản phẩm có nhiều Skin.Category = false nhất cho từng Category = true
                        var productId = await _dbContext.Products
                            .Where(p => p.ProductDetails.Any(pd => pd.ProductId == categoryProductId))
                            .OrderByDescending(p => p.ProductDetails.Count(pd => skinIds.Contains(pd.SkinId) && !pd.Skins.Category))
                            .Select(p => p.Id)
                            .FirstOrDefaultAsync();

                        // Nếu tìm thấy sản phẩm thì thêm vào danh sách đã chọn
                        if (productId != Guid.Empty)
                        {
                            selectedProductIds.Add(productId);
                        }
                    }

                    query = query.Where(p => selectedProductIds.Contains(p.Id));
                    break;
                default:
                    query = query.Include(e => e.ProductDetails)
                        .ThenInclude(e => e.Skins)
                        .Where(e =>
                            e.ProductDetails.Any(pd => skinIds.Contains(pd.SkinId) && pd.Skins.Category)
                        );
                    break;
            }


            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            var itemCount = await query.CountAsync();
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            
            if (pageIndex.HasValue && pageSize.HasValue)
            {
                int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
                int validPageSize = pageSize.Value > 0 ? pageSize.Value : 10;

                query = query.Skip(validPageIndex * validPageSize).Take(validPageSize);
            }

            var result = new Pagination<Product>()
            {
                PageIndex = pageIndex ?? 0,
                PageSize = pageSize ?? 10,
                TotalItemsCount = itemCount,
                Items = await query.ToListAsync(),
            };

            return result;
        }
        public async Task<Guid> CreatePersonalAnalystAsync(PersonalAnalyst personalAnalyst)
        {
            personalAnalyst.CreationDate = _timeService.GetCurrentTime();
            personalAnalyst.StartDate = _timeService.GetCurrentTime();
            personalAnalyst.CreatedBy = _claimsService.GetCurrentUserId;
            var result = await _dbSet.AddAsync(personalAnalyst);
            return result.Entity.Id;
        }

        public async Task<PersonalAnalyst> GetLastPersonalAnalystAsync()
        {
            var userId = _claimsService.GetCurrentUserId.ToString();
            var personalAnalyst = await _dbContext.PersonalAnalysts
            .Where(e => e.UserId == userId)
            .OrderByDescending(e => e.StartDate)
            .FirstOrDefaultAsync();
            if (personalAnalyst == null) throw new Exception();
            return personalAnalyst;
        }

        public async Task<List<Guid?>> GetSkinIdsByPersonalAnalystIdAsync(string personalAnalystId)
        {
            // Thực hiện truy vấn để lấy các skinId của personalAnalystId từ cơ sở dữ liệu
            var skinIds = await _dbContext.PersonalAnalystDetails
                                        .Where(pad => pad.PersonalAnalystId == Guid.Parse(personalAnalystId))
                                        .Select(pad => pad.SkinId)
                                        .Distinct()
                                        .ToListAsync();

            return skinIds;
        }

        public async Task<bool> CheckExistPersonalAnalystAsync(string userId)
        {
            var personalAnalyst = await _dbContext.PersonalAnalysts
            .Where(e => e.UserId == userId)
            .FirstOrDefaultAsync();
            if (personalAnalyst == null) return false;
            return true;
        }
        public async Task<Pagination<Method>> SuggestMethodAsync(Guid personalAnalystId, int? pageIndex = null, int? pageSize = null)
        {
            var skinIds = await _dbContext.PersonalAnalystDetails
                .Where(e => e.PersonalAnalystId == personalAnalystId)
                .Select(e => e.SkinId)
                .Distinct()
                .ToListAsync();

            var methodsQuery = _dbContext.Methods
                 .Include(e => e.MethodDetails)
                 .ThenInclude(e => e.Skins)
                 .Where(e => e.MethodDetails.Any(md => skinIds.Contains(md.SkinId) && md.Skins.Category)||
                               e.MethodDetails.Any(md => skinIds.Contains(md.SkinId) && !md.Skins.Category));

            var itemCount = await methodsQuery.CountAsync();

            if (pageIndex.HasValue && pageSize.HasValue)
            {
                int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
                int validPageSize = pageSize.Value > 0 ? pageSize.Value : 10;

                methodsQuery = methodsQuery.Skip(validPageIndex * validPageSize).Take(validPageSize);
            }

            var pagination = new Pagination<Method>()
            {
                PageIndex = pageIndex ?? 0,
                PageSize = pageSize ?? 10,
                TotalItemsCount = itemCount,
                Items = await methodsQuery.ToListAsync()
            };

            return pagination;
        }
    }
}
