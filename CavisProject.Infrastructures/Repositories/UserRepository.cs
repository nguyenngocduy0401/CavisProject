using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.Repositories;
using CavisProject.Domain.Entity;
using CavisProject.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Infrastructures.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly ICurrentTime _currentTime;
        private readonly RoleManager<Role> _roleManager;
        private readonly IClaimsService _claimsService;

        public UserRepository(AppDbContext context, ICurrentTime currentTime,
            IClaimsService claimsService, UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            _dbContext = context;
            _currentTime = currentTime;
            _claimsService = claimsService;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<User> GetByPhoneNumberAsync(string phoneNumber) =>
            await _dbContext.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);

        public virtual async Task<Pagination<User>> GetFilterAsync(
        Expression<Func<User, bool>>? filter = null,
        Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null,
        string includeProperties = "",
        int? pageIndex = null,
        int? pageSize = null,
        string? role=null,
        IsActivityEnum? isActivity= null,
        string? foreignKey = null,
        object? foreignKeyId = null)
        {
            IQueryable<User> query = _dbContext.Users;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(role))
            {
                var usersInRole = await _userManager.GetUsersInRoleAsync(role);
                var userIdsInRole = usersInRole.Select(u => u.Id);
                query = query.Where(u => userIdsInRole.Contains(u.Id));
            }
            if (isActivity.HasValue)
            {
                switch (isActivity)
                {
                    case IsActivityEnum.Activity:
                        query = query.Where(u => (u.LockoutEnd <= DateTimeOffset.UtcNow) || (u.LockoutEnd == null));
                        break;
                    case IsActivityEnum.Inactivity:
                        query = query.Where(u => u.LockoutEnd > DateTimeOffset.UtcNow);
                        break;
                }
                    
            }
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            var itemCountTask = query.CountAsync();

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (!string.IsNullOrEmpty(foreignKey) && foreignKeyId != null)
            {
                if (foreignKeyId is Guid guidValue)
                {
                    query = query.Where(e => EF.Property<Guid>(e, foreignKey) == guidValue);
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

            if (pageIndex.HasValue && pageSize.HasValue)
            {
                int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
                int validPageSize = pageSize.Value > 0 ? pageSize.Value : 10;

                query = query.Skip(validPageIndex * validPageSize).Take(validPageSize);
            }

            var itemCount = await itemCountTask;

            var result = new Pagination<User>()
            {
                PageIndex = pageIndex ?? 0,
                PageSize = pageSize ?? 10,
                TotalItemsCount = itemCount,
                Items = await query.ToListAsync(),
            };

            return result;
        }


        public async Task AddAsync(User user)
        {
            await _dbContext.AddAsync(user);
        }
        public async Task<bool> CheckUserAttributeExisted(string attributeValue, string attributeType)
        {
            if (string.IsNullOrEmpty(attributeValue))
            {
                throw new ArgumentException("Attribute value cannot be null or empty", nameof(attributeValue));
            }

            return attributeType switch
            {
                "Email" => await _dbContext.Users.AnyAsync(u => u.Email == attributeValue),
                "PhoneNumber" => await _dbContext.Users.AnyAsync(u => u.PhoneNumber == attributeValue),
                "UserName" => await _dbContext.Users.AnyAsync(u => u.UserName == attributeValue),
                _ => throw new ArgumentException("Invalid attribute type", nameof(attributeType)),
            };
        }

        public async Task<User> GetUserByUserNameAndPassword(string username, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == username);
            bool invalid = await _userManager.CheckPasswordAsync(user, password);
            if (user is null && invalid is false)
            {
                throw new Exception("Username or password is not correct!");
            }
            return user;
        }

        public async Task<List<string>> GetRolesByUserId(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return (List<string>)(user != null ? await _userManager.GetRolesAsync(user) : new List<string>());
        }

        public Task<string> GetUserByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
