using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.PackagePremium;
using CavisProject.Application.ViewModels.ProductCategoryViewModel;
using CavisProject.Application.ViewModels.RegistPreniumViewModel;
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
            #region Skin
            CreateMap<CreateSkinTypeViewModel, Skin>();
            CreateMap<Skin, SkinViewModel>();
            CreateMap<Skin, CreateSkinTypeViewModel>();

            #endregion
            #region ProductCategory
            CreateMap<CreateProductCategoryViewModel, ProductCategory>();
            CreateMap<ProductCategory, CreateProductCategoryViewModel>();
            #endregion
            #region Supplier
            CreateMap<CreateSupplierViewModel, Supplier>();
            CreateMap<Supplier, CreateSupplierViewModel>();
            CreateMap<UserRegisterModel, User>()
                .ForMember(dest => dest.PasswordHash, src => src.MapFrom(x => x.Password));
            #endregion
            #region Prenium
            CreateMap<RegistPremiumViewModel,PackagePremium>();
            CreateMap<UpgradeToPremiumViewModel, User>();
            CreateMap<Pagination<User>, Pagination<UserViewModel>>()
           .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<User, UserViewModel>()
           .ForMember(dest => dest.PackagePremiumName, opt => opt.Ignore());
            CreateMap<Pagination<PackagePremium>, Pagination<PackagePreniumViewModel>>().ReverseMap();
            CreateMap<PackagePremium, PackagePreniumViewModel>().ReverseMap();
            #endregion
        }
    }
}
