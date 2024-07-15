using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.PackagePremiumViewModels;
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
using CavisProject.Application.ViewModels.MethodViewModels;
using CavisProject.Application.ViewModels.Calendar;
using CavisProject.Application.ViewModels.AppointmentViewModel;
using CavisProject.Application.ViewModels.CalendarViewModel;
using CavisProject.Application.ViewModels.SkincareRoutineViewModels;
using CavisProject.Application.ViewModels.PersonalImageViewModels;

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

            CreateMap<User, UserViewModel>();
             


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
            CreateMap<Supplier, SupplierViewModel>();
            CreateMap<ProductCategory, ProductCategoryViewModel>()
           .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategoryName));

            CreateMap<UserRegisterModel, User>()
                .ForMember(dest => dest.PasswordHash, src => src.MapFrom(x => x.Password));
            #endregion
            #region Premium
            CreateMap<RegistPremiumViewModel, PackagePremium>();
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
            #region Method
            CreateMap<CreateMethodViewModel, Method>();
            CreateMap<Method, MethodViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.MethodName, opt => opt.MapFrom(src => src.MethodName))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.URLImage, opt => opt.MapFrom(src => src.URLImage))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FullName))
            .ForMember(dest => dest.UserAvatar, opt => opt.MapFrom(src => src.User.URLImage))
            .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate));
            CreateMap<Pagination<Method>, Pagination<MethodViewModel>>().ReverseMap();
            CreateMap<string, bool>().ConvertUsing(str => str == "true" || str == "1");
            #endregion
            #region Calendar and Appointment
            CreateMap<Calendar, CalendarViewModel>().ReverseMap();
            CreateMap<Appointment, CreateAppointmentViewModel>().ReverseMap();
            CreateMap<CalendarDetail, ExpertAvailabilityViewModel>()
           .ForMember(dest => dest.ExpertId, opt => opt.MapFrom(src => src.UserId))
           .ForMember(dest => dest.ExpertName, opt => opt.MapFrom(src => src.User.FullName))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.URLImage, opt => opt.MapFrom(src => src.User.URLImage));
            CreateMap<CalendarDetail, ExpertAvailabilityViewModel>()
                 .ForMember(dest => dest.ExpertId, opt => opt.MapFrom(src => src.User.Id))
                 .ForMember(dest => dest.ExpertName, opt => opt.MapFrom(src => src.User.FullName))
                 .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                 .ForMember(dest => dest.URLImage, opt => opt.MapFrom(src => src.User.URLImage));
           
            CreateMap<User, ExpertAvailabilityViewModel>()
            .ForMember(dest => dest.ExpertId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ExpertName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.URLImage, opt => opt.MapFrom(src => src.URLImage));
            // CreateMap<List<CalendarDetailViewModel>,List<CalendarDetail>>().ReverseMap();
            CreateMap<Appointment, AppointmentViewModel>()
           .ForMember(dest => dest.AppointmentId, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime.Value.TimeOfDay))
           .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.Value.TimeOfDay))
           .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.Value.Date))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
           
            #endregion
            #region SkincareRoutine
            CreateMap<UpdateSkincareRoutineModel, SkincareRoutine>();
            CreateMap<SkincareRoutine, SkincareRoutineViewModel>();
            #endregion
            #region PersonalImage
            CreateMap<CreatePersonalImageViewModel, PersonalImage>();
            CreateMap<Pagination<PersonalImage>, Pagination<PersonalImageViewModel>>().ReverseMap();
            CreateMap<PersonalImage, PersonalImageViewModel>();

            #endregion
        }
    }
}
