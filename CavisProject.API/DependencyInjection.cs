using CavisProject.API.Services;
using CavisProject.Application.Interfaces;
using CavisProject.Application;
using CavisProject.Infrastructures;
using FluentValidation;
using Microsoft.OpenApi.Models;
using System.Diagnostics;
using CavisProject.Infrastructures.DataInitializer;
using CavisProject.API.Validator.AuthenticationValidator;
using CavisProject.Application.ViewModels.UserViewModels;
using CavisProject.API.Validator.SkinTypeValdator;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Application.ViewModels.ProductCategoryViewModel;
using CavisProject.Domain.Entity;
using CavisProject.API.Validator.ProductValidator.ProductCategoryValidator;
using CavisProject.Application.ViewModels.SupplierViewModel;
using CavisProject.API.Validator.ProductValidator.SupplierViewModel;
using CavisProject.Application.ViewModels.PackagePremium;
using CavisProject.API.Validator.PackageValidator;

namespace CavisProject.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIService(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "CavisAPI", Version = "v1" });
                option.EnableAnnotations();
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            services.AddHealthChecks();
            services.AddSingleton<Stopwatch>();
            services.AddScoped<IClaimsService, ClaimsService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddHttpContextAccessor();
      /*      services.AddHostedService<SetupIdentityDataSeeder>();*/
            services.AddControllers();
            services.AddLogging();

            #region Seed
            /*services.AddHostedService<SetupIdentityDataSeeder>();*/
            services.AddScoped<RoleInitializer>();
            services.AddScoped<AccountInitializer>();
            #endregion
            #region Validator
            services.AddTransient<IValidator<UserRegisterModel>, UserRegisterValidation>();
            services.AddTransient<IValidator<CreateSkinTypeViewModel>, CreateSkinTypeValidator>();
            services.AddTransient<IValidator<CreateProductCategoryViewModel>, ProductCategoryValidator>();
            services.AddTransient<IValidator<CreateSupplierViewModel>, SupplierValidator>();
            services.AddTransient<IValidator<UserResetPasswordModel>, UserResetPasswordValidator>();
            services.AddTransient<IValidator<CreatePackagePremiumViewModel>, CreatePackagePremiumViewModelValidator>();
            #endregion

            return services;
        }
    }
}