using CavisProject.Domain.Entity;
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
            

            #endregion

            #region Repository DI
           
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