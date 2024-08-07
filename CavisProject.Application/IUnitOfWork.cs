﻿using CavisProject.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application
{
    public interface IUnitOfWork
    {
        public IAppointmentRepository AppointmentRepository { get; }
        public IAppointmentDetailRepository AppointmentDetailRepository { get; }
        public ICalendarRepository CalendarRepository { get; }
        public ICalendarDetailRepository CalendarDetailRepository { get; }
        public IMethodDetailRepository MethodDetailRepository { get; }
        public IMethodSkinCareRepository MethodSkinCareRepository { get; }
        public IPackageDetailRepository PackageDetailRepository { get; }
        public IPackagePremiumRepository PackagePremiumRepository { get; }
        public IPersonalAnalystRepository PersonalAnalystRepository { get; }
        public IPersonalAnalystDetailRepository PersonalAnalystDetailRepository { get; }
        public IPersonalImageRepository PersonalImageRepository { get; }
        public IPersonalMethodDetailRepository PersonalMethodDetailRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IProductCategoryRepository ProductCategoryRepository { get; }
        public IProductDetailRepository ProductDetailRepository { get; }
        public ISkinTypeRepository SkinTypeRepository { get; }
        public ISkinConditionRepository SkinConditionRepository { get; }
        public IUserRepository UserRepository { get; }
        public ISupplierRepository SupplierRepository { get; }
        public ITransactionRepository TransactionRepository { get; }
        public IWishListRepository WishListRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IRefreshTokenRepository RefreshTokenRepository { get; }
        public IMethodMakeUpRepository MethodMakeUpRepository { get; }
        public ISkincareRoutineRepository SkincareRoutineRepository { get; }   
        public Task<int> SaveChangeAsync();

    }
}
