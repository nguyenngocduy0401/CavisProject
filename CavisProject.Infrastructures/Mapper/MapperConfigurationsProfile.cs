using AutoMapper;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
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
            CreateMap<CreateSkinTypeViewModel, SkinType>();
            CreateMap<SkinTypeViewModel, SkinType>();
        }
    }
}
