﻿using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Domain.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
namespace CavisProject.Application.Services
{
    public class SkinTypeService : ISkintypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateSkinTypeViewModel> _validatorCreateSkinType;
        public SkinTypeService( IUnitOfWork unitOfWork , IMapper mapper , IValidator<CreateSkinTypeViewModel> validatorCreateSkintype ,IClaimsService claimsService)
        {
            _mapper= mapper;
            _unitOfWork= unitOfWork;
            _validatorCreateSkinType= validatorCreateSkintype;
        }

        
        public async Task<ApiResponse<CreateSkinTypeViewModel>> CreateSkinType(CreateSkinTypeViewModel createSkinType)
        {
            var response = new ApiResponse<CreateSkinTypeViewModel>();
            try
            {
                var skinType = _mapper.Map<SkinType>(createSkinType);
                FluentValidation.Results.ValidationResult validationResult = await _validatorCreateSkinType.ValidateAsync(createSkinType);
                if(validationResult.IsValid)
                {
                    response.isSuccess = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }
                else
                {
                    await _unitOfWork.SkinTypeRepository.AddAsync(skinType);
                    var isSuccess = await _unitOfWork.SaveChangeAsync()>0;
                    if (isSuccess is false)
                    {
                        throw new Exception("Create Skintype is fail!");
                    }
                    response.Data= _mapper.Map<CreateSkinTypeViewModel>(createSkinType);
                    response.Message = "Create Skintype is success";                
                   
                }
            }catch(DbException ex)
            {
                response.isSuccess = true;
                response.Message= ex.Message;

            }
            catch(Exception ex) {
                response.isSuccess = false;
                response.Message= ex.Message;
            }
            return response;
           
        }


        public Task<ApiResponse<bool>> DeleteSkinType(string skinTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<IEnumerable< SkinTypeViewModel>>> GetSkinConditions(SkinTypeViewModel skinCondition)
        {
            var skinType = await _unitOfWork.SkinTypeRepository.GetAllWithCategoryTrueAsync();
            var result = _mapper.Map<IEnumerable<SkinTypeViewModel>>(skinCondition);
            return new ApiResponse<IEnumerable<SkinTypeViewModel>>
            {
                isSuccess = true,
                Data = result
            };
        }

        public Task<ApiResponse<SkinTypeViewModel>> GetSkinType(SkinTypeViewModel skinType)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<CreateSkinTypeViewModel>> UpdateSkinType(CreateSkinTypeViewModel updateSkinType)
        {
            throw new NotImplementedException();
        }
    }
}
