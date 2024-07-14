﻿using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.AppointmentViewModel;
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
    public interface IUserRepository
    {
        Task<User> GetByPhoneNumberAsync(string phoneNumber);
        Task<List<string>> GetRolesByUserId(string userId);
        Task<Pagination<User>> GetFilterAsync(
           Expression<Func<User, bool>>? filter = null,
           Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null,
           string includeProperties = "",
           int? pageIndex = null,
           int? pageSize = null,
           string? role = null,
           IsActivityEnum? isActivity = null,
            UserPremiumStatusEnum? status = null,
           string? foreignKey = null,
           object? foreignKeyId = null);
        Task<bool> CheckUserAttributeExisted(string attributeValue, string attributeType);
        Task<User> GetUserByUserNameAndPassword(string username, string password);
        Task AddAsync(User user);
        Task<string> GetUserByUserId(string userId);
        Task<string> GetCurrentUserRoleAsync(string userId);
        Task<string?> GetPackagePremiumIdAsync(string userId);
        Task<Pagination<User>> GetAvailableSkincareExpertsAsync(AvailableExpertSkincareFilterViewModel filter);
    }
}
