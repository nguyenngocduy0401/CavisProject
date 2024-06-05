﻿using AutoMapper;
using CavisProject.Application.ViewModels.ProductCategoryViewModel;
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

            #endregion
            #region SkinType
            CreateMap<CreateSkinTypeViewModel, Skin>();
            CreateMap<SkinTypeViewModel, Skin>();
            CreateMap<Skin, CreateSkinTypeViewModel>();

            #endregion
            #region ProductCategory
            CreateMap<CreateProductCategoryViewModel, ProductCategory>();
            CreateMap<ProductCategory, CreateProductCategoryViewModel>();
            #endregion
            #region Supplier
            CreateMap<CreateSupplierViewModel, Supplier>();
            CreateMap<Supplier, CreateSupplierViewModel>();
            #endregion
            #region Product
            CreateMap<CreateProductViewModel, Product>();
            CreateMap<Product, CreateProductViewModel>();
            #endregion
        }
    }
}
