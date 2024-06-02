using AutoMapper;
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
            #endregion
        }
    }
}
