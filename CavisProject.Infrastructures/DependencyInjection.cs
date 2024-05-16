﻿using CavisProject.Application;
using CavisProject.Application.Interfaces;
using CavisProject.Application.Repositories;
using CavisProject.Application.Services;
using CavisProject.Domain.Entity;
using CavisProject.Infrastructures.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Infrastructures
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructuresService(this IServiceCollection services, string databaseConnection)
        {
            #region Service DI
            services.AddScoped<ICurrentTime, CurrentTime>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IAppointmentDetailService, AppointmentDetailService>(); 
            services.AddScoped<ICalendarService, CalendarService>();
            services.AddScoped<IMethodDetailService, MethodDetailService>();
            services.AddScoped<IMethodService, MethodService>();
            services.AddScoped<IPackageDetailService, PackageDetailService>();
            services.AddScoped<IPackagePreniumService, PackagePreniumService>();
            services.AddScoped<IPersonalAnalystDetailService, PersonalAnalystDetailService>();
            services.AddScoped<IPersonalAnalystService, PersonalAnalystService>();
            services.AddScoped<IPersonalImageService, PersonalImageService>();
            services.AddScoped<IPersonalMethodDetailService ,PersonalMethodDetailService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IProductDetailService ,ProductDetailService>();
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<ISkintypeService, SkinTypeService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IWishListService, WishListService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            #endregion

            #region Repository DI
            services.AddScoped<IAppointmentDetailRepository, AppointmentDetailRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<ICalendarRepository,CalendarRepository>();
            services.AddScoped<IMethodDetailRepository, MethodDetailRepository>();
            services.AddScoped<IMethodRepository, MethodRepository>();
            services.AddScoped<IPackageDetailRepository, PackageDetailRepository>();
            services.AddScoped<IPackagePreniumRepository, PackagePreniumRepository>();
            services.AddScoped<IPersonalAnalystDetailRepository, PersonalAnalystDetailRepository>();
            services.AddScoped<IPersonalAnalystRepository, PersonalAnalystRepository>();
            services.AddScoped<IPersonalImageRepository, PersonalImageRepository>();
            services.AddScoped<IPersonalMethodDetailRepository, PersonalMethodDetailRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ISkinTypeRepository, SkinTypeRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IWishListRepository, WishListRepository>();



            #endregion
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


            services.Configure<IdentityOptions>(options =>
            {
                // Set your desired password requirements here
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6; // Set your desired minimum length
                options.Password.RequiredUniqueChars = 0; // Set your desired number of unique characters
            });

            // ATTENTION: if you do migration please check file README.md
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(databaseConnection));
/*
            services.AddAutoMapper(typeof(MapperConfigurationsProfile).Assembly);*/


            return services;
        }
    }
}