using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Domain.Entity;
using FluentValidation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Services
{
    public class SkinTypeService : ISkintypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateSkinTypeViewModel> _validatorCreateSkinType;
        public SkinTypeService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateSkinTypeViewModel> validatorCreateSkintype, IClaimsService claimsService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validatorCreateSkinType = validatorCreateSkintype;
        }


        public async Task<ApiResponse<CreateSkinTypeViewModel>> CreateSkinType(CreateSkinTypeViewModel createSkinType)
        {
            var response = new ApiResponse<CreateSkinTypeViewModel>();
            try
            {
                var skinType = _mapper.Map<Skin>(createSkinType);
                var skinTypeList = _unitOfWork.SkinTypeRepository.Find(s => s.SkinsName == createSkinType.SkinsName);
                var isNameExist = skinTypeList.Any();
                if (isNameExist)
                {
                    throw new Exception("Skin type Name is exist!");
                }else
                {
                    FluentValidation.Results.ValidationResult validationResult = await _validatorCreateSkinType.ValidateAsync(createSkinType);
                    if (!validationResult.IsValid)
                    {
                        response.isSuccess = false;
                        response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                        return response;
                    }
                    else
                    {
                        skinType.Category = true;
                        await _unitOfWork.SkinTypeRepository.AddAsync(skinType);
                        var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                        if (isSuccess is false)
                        {
                            throw new Exception("Create Skintype is fail!");
                        }
                        response.Data = _mapper.Map<CreateSkinTypeViewModel>(createSkinType);
                        response.Message = "Create Skintype is success";

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


        public async Task<ApiResponse<bool>> DeleteSkinType(string skinTypeId)
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

                    throw new Exception("SkinType is already deleted");

                }
                _unitOfWork.SkinTypeRepository.SoftRemove(exist);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
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



     
        public async Task<ApiResponse<CreateSkinTypeViewModel>> UpdateSkinType(CreateSkinTypeViewModel updateSkinType, string skinTypeId)
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
                    if (exist is null)
                    {
                        throw new Exception("Skintype not found");

                    }
                    else
                    {
                        var update = _mapper.Map(updateSkinType, exist);
                        var skinTypeList = _unitOfWork.SkinTypeRepository.Find(s => s.SkinsName == update.SkinsName);
                        var isNameExist = skinTypeList.Any();
                        if (isNameExist)
                        {
                            throw new Exception("Skin Condition Name is exist!");
                        }
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

        public async Task<ApiResponse<Pagination<SkinViewModel>>> FilterSkinType(SkinFilterModel skinTypeFilterModel)
        {
            var response = new ApiResponse<Pagination<SkinViewModel>>();

            try
            {
                var paginationResult = _unitOfWork.SkinTypeRepository.GetFilter(
                    filter: s =>
                        (string.IsNullOrEmpty(skinTypeFilterModel.SkinTypeName) || s.SkinsName.Contains(skinTypeFilterModel.SkinTypeName)) &&
                        (string.IsNullOrEmpty(skinTypeFilterModel.Description) || s.Description.Contains(skinTypeFilterModel.Description)) &&
                        s.Category == true,
                    pageIndex: skinTypeFilterModel.PageIndex,
                    pageSize: skinTypeFilterModel.PageSize
                ); ;
                var skinTypeViewModels = _mapper.Map<List<SkinViewModel>>(paginationResult.Items);
                var paginationViewModel = new Pagination<SkinViewModel>
                {
                    PageIndex = paginationResult.PageIndex,
                    PageSize = paginationResult.PageSize,
                    TotalItemsCount = paginationResult.TotalItemsCount,
                    Items = skinTypeViewModels
                };
                response.Data = paginationViewModel;
                response.isSuccess = true;
                response.Message = "Filtered skin types retrieved successfully";
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = "Error occurred while filtering skin types: " + ex.Message;
            }

            return response;
        }

        public async Task<ApiResponse<SkinViewModel>> GetSkinTypeById(string id)
        {
            var response = new ApiResponse<SkinViewModel>();

            try
            {
                var skinType= await _unitOfWork.SkinTypeRepository.GetByIdAsync(Guid.Parse(id));
                if (skinType == null || skinType.Category  == false) throw new Exception("Not find skintype!");
                var skinTypeView = _mapper.Map<SkinViewModel>(skinType);
                response.Data = skinTypeView;
                response.isSuccess = true;
                response.Message = "Filtered skin types retrieved successfully";
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message =  ex.Message;
            }

            return response;
        }
    }
}

