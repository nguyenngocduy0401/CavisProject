using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.SkintypeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Services
{
    public class SkinTypeService : ISkintypeService

    {
        private readonly IMapper _mapper;
        public Task<ApiResponse<CreateSkinTypeViewModel>> CreateSkinType(CreateSkinTypeViewModel createSkinTypeViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> DeleteSKinType(string skinTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<SkinTypeViewModel>> GetSKinType(SkinTypeViewModel skinTypeViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<CreateSkinTypeViewModel>> UpdateSkinType(CreateSkinTypeViewModel updateSkinType)
        {
            throw new NotImplementedException();
        }
    }
}
