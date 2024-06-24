﻿using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.PackagePremium;
using CavisProject.Application.ViewModels.ProductCategoryViewModel;
using CavisProject.Application.ViewModels.RegistPreniumViewModel;
using CavisProject.Application.ViewModels.PersonalAnalystViewModels;
using CavisProject.Application.ViewModels.ProductViewModel;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Application.ViewModels.SupplierViewModel;
using CavisProject.Application.ViewModels.UserViewModels;
using CavisProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Infrastructures.Mappers
{
    public class MapperConfigurationsProfile : Profile
    {
        public MapperConfigurationsProfile()
        {
            #region User
            CreateMap<UserLoginModel, User>();
            CreateMap<UserRegisterModel, User>()
                .ForMember(dest => dest.PasswordHash, src => src.MapFrom(x => x.Password));
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Pagination<User>, Pagination<UserViewModel>>();
            CreateMap<CreateUserModel, User>()
                .ForMember(dest => dest.PasswordHash, src => src.MapFrom(x => x.Password));
            CreateMap<UserPackageViewModel, User>();
            CreateMap<UserViewModel, User>();
            CreateMap<UserViewModel, PackagePremium>();
            CreateMap<User, UserViewModel>().ReverseMap();
             


            #endregion
            #region Skin
            CreateMap<CreateSkinTypeViewModel, Skin>();
            CreateMap<Skin, SkinViewModel>();
            CreateMap<Skin, CreateSkinTypeViewModel>();
            #endregion
            #region ProductCategory
            CreateMap<CreateProductCategoryViewModel, ProductCategory>();
            CreateMap<ProductCategory, CreateProductCategoryViewModel>();
            CreateMap<ProductCategoryViewModel, ProductCategory>().ReverseMap();
            #endregion
            #region Supplier
            CreateMap<CreateSupplierViewModel, Supplier>();
            CreateMap<Supplier, CreateSupplierViewModel>();
            CreateMap<SupplierViewModel, Supplier>();
            CreateMap<UserRegisterModel, User>()
                .ForMember(dest => dest.PasswordHash, src => src.MapFrom(x => x.Password));
            #endregion
            #region Premium
            CreateMap<RegistPremiumViewModel,PackagePremium>();
            CreateMap<UpgradeToPremiumViewModel, User>();
            CreateMap<Pagination<User>, Pagination<UserViewModel>>()
           .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<PackageDetail, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));
            CreateMap<Pagination<PackagePremium>, Pagination<PackagePremiumViewModel>>().ReverseMap();
            CreateMap<PackagePremium, PackagePremiumViewModel>().ReverseMap();
            CreateMap<CreatePackagePremiumViewModel, PackagePremium>();
            CreateMap<PackageDetail, PackageDetailViewModel>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
            .ForMember(dest => dest.PackagePremiumId, opt => opt.MapFrom(src => src.PackagePremiumId));
            #endregion
            #region Product
            CreateMap<CreateProductViewModel, Product>();
            CreateMap<Product, CreateProductViewModel>();
            CreateMap<Pagination<Product>, Pagination<ProductViewModel>>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            #endregion
            #region PersonalAnalyst
            CreateMap<Pagination<PersonalAnalyst>, Pagination<PersonalAnalystViewModel>>();
            CreateMap<PersonalAnalyst, PersonalAnalystViewModel>();
            #endregion
        }
    }
}
