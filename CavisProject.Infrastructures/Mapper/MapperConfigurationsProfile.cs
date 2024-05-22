using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.SkintypeViewModel;
using CavisProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Infrastructures.Mapper
{
    public class MapperConfigurationsProfile :Profile
    {
        public MapperConfigurationsProfile() 
        {
            CreateMap(typeof(Pagination<>), typeof(Pagination<>));
            CreateMap<CreateSkinTypeViewModel, SkinType>();
            CreateMap<SkinTypeViewModel, SkinType>();
        }
    }
}
