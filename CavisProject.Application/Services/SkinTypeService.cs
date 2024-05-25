using AutoMapper;
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
using System.Diagnostics.Contracts;

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
                if(!validationResult.IsValid)
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
                response.isSuccess = false;
                response.Message= ex.Message;

            }
            catch(Exception ex) {
                response.isSuccess = false;
                response.Message= ex.Message;
            }
            return response;
           
        }


        public  async Task<ApiResponse<bool>> DeleteSkinType(string skinTypeId)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var exist = await _unitOfWork.SkinTypeRepository.GetByIdAsync(Guid.Parse(skinTypeId));
                if (exist == null)
                {
                    throw new Exception("No SkinType Exit");
                }
                if (exist.IsDeleted)
                {
                
                    throw new Exception( "SkinType is already deleted");
                  
                }
                _unitOfWork.SkinTypeRepository.SoftRemove(exist);
                var isSuccess = await _unitOfWork.SaveChangeAsync()>0;
                if (isSuccess is false)
                {
                    throw new Exception("Delete Skintype is fail");
                }
                response.Data = _mapper.Map<bool>(skinTypeId);

                response.Message = "Delete Skintype is success";
            }
            catch (DbException ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;

            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

       

        public async Task<ApiResponse<List<SkinTypeViewModel>>> GetSkinConditions()
        {
            try
            {
                var skinTypes = await _unitOfWork.SkinTypeRepository.GetAllWithCategoryFalseAsync();
                var result = _mapper.Map<List<SkinTypeViewModel>>(skinTypes);

                return new ApiResponse<List<SkinTypeViewModel>>
                {
                    isSuccess = true,
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<SkinTypeViewModel>>
                {
                    isSuccess = false,
                    Message = $"An error occurred while retrieving skin types: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<List<SkinTypeViewModel>>> GetSkinType()
        {
            var response = new ApiResponse<List<SkinTypeViewModel>>();
            try
            {
                var skinTypes = await _unitOfWork.SkinTypeRepository.GetAllWithCategoryTrueAsync();
                var result = _mapper.Map<List<SkinTypeViewModel>>(skinTypes);

                return new ApiResponse<List<SkinTypeViewModel>>
                {
                    isSuccess = true,
                    Data = result
                };
            }
            catch (DbException ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;

            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse<CreateSkinTypeViewModel>> UpdateSkinType (CreateSkinTypeViewModel updateSkinType ,string skinTypeId)
        {
            var response = new ApiResponse<CreateSkinTypeViewModel>();
            try
            {
                var exist = await _unitOfWork.SkinTypeRepository.GetByIdAsync(Guid.Parse(skinTypeId));
             
                FluentValidation.Results.ValidationResult validationResult = await _validatorCreateSkinType.ValidateAsync(updateSkinType);
                if (validationResult.IsValid)
                {
                    response.isSuccess = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }
                else
                {
                    if(exist is null)
                    {
                        throw new Exception("Skintype not found");

                    }
                    else
                    {
                        var update = _mapper.Map(updateSkinType, exist);
                        var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                      
                        if (isSuccess is false)
                        {
                            throw new Exception("Update Skintype is fail");
                        }
                        response.Data = _mapper.Map<CreateSkinTypeViewModel>(skinTypeId);

                        response.Message = "Update Skintype is success";
                    }

                }
            }
            catch (DbException ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;

            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        
    }
}
