using CavisProject.Application.Commons;
using CavisProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByPhoneNumberAsync(string phoneNumber);
        Task<List<string>> GetRolesByUserId(string userId);
        Task<Pagination<User>> GetUsersByFilter
        (string search, string role, int pageIndex = 1, int pageSize = 10);
        Task<bool> CheckUserAttributeExisted(string attributeValue, string attributeType);
        Task<User> GetUserByUserNameAndPassword(string username, string password);
        Task AddAsync(User user);
    }
}
