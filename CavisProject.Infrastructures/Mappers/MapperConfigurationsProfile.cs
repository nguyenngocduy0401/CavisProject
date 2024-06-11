using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.PersonalAnalystViewModels;
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
            CreateMap<UserRegisterModel, User>()
                .ForMember(dest => dest.PasswordHash, src => src.MapFrom(x => x.Password));
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Pagination<User>, Pagination<UserViewModel>>();
            CreateMap<CreateUserModel, User>()
                .ForMember(dest => dest.PasswordHash, src => src.MapFrom(x => x.Password));
            #endregion
            #region Skin
            CreateMap<CreateSkinTypeViewModel, Skin>();
            CreateMap<Skin, SkinViewModel>();
            CreateMap<Skin, CreateSkinTypeViewModel>();
            #endregion
            #region ProductCategory
            CreateMap<CreateProductCategoryViewModel, ProductCategory>();
            CreateMap<ProductCategory, CreateProductCategoryViewModel>();
            CreateMap<ProductCategoryViewModel, ProductCategory>();
            #endregion
            #region Supplier
            CreateMap<CreateSupplierViewModel, Supplier>();
            CreateMap<Supplier, CreateSupplierViewModel>();
            CreateMap<SupplierViewModel, Supplier>();
            CreateMap<UserRegisterModel, User>()
                .ForMember(dest => dest.PasswordHash, src => src.MapFrom(x => x.Password)); 
            #endregion
            #region Product
            CreateMap<CreateProductViewModel, Product>();
            CreateMap<Product, CreateProductViewModel>();
            #endregion
            #region PersonalAnalyst
            CreateMap<Pagination<PersonalAnalyst>, Pagination<PersonalAnalystViewModel>>()
                 .ForMember(dest => dest.Items, opt => opt.MapFrom(src =>
        src.Items.Select(x =>
            new PersonalAnalystViewModel
            {
                PersonalAnalystDetails = x.PersonalAnalystDetails,
                
            })));
            CreateMap<PersonalAnalyst, PersonalAnalystViewModel>()
                .ForMember(dest => dest.PersonalAnalystDetails, src => src.MapFrom(x => x.PersonalAnalystDetails));
            #endregion
        }
    }
}
