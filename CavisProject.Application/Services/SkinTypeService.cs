using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Domain.Entity;
using FluentValidation;
using FluentValidation.Results;
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
        public SkinTypeService(IUnitOfWork unitOfWork,
            IMapper mapper, IValidator<CreateSkinTypeViewModel> validatorCreateSkinType, 
            IClaimsService claimsService)
        {
            _claimsService = claimsService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validatorCreateSkinType = validatorCreateSkinType;
        }


        public async Task<ApiResponse<bool>> CreateSkinTypeAsync(CreateSkinTypeViewModel createSkinType)
        {
            var response = new ApiResponse<bool>();
            try
            {
                ValidationResult validationResult = await _validatorCreateSkinType.ValidateAsync(createSkinType);
                if (!validationResult.IsValid)
                {
                    response.isSuccess = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }
                var skinType = _mapper.Map<Skin>(createSkinType);

                var skinTypeList = _unitOfWork.SkinTypeRepository.Find(s => s.SkinsName == createSkinType.SkinsName);
                var isNameExist = skinTypeList.Any();
                if (isNameExist)
                {
                    response.Message = "Tên đã tồn tại";

                    response.isSuccess = true;
                    response.Data = false;
                    return response;
                }
                
                   
                   
                        skinType.Category = true;
                        await _unitOfWork.SkinTypeRepository.AddAsync(skinType);
                        var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                        if (isSuccess is false)
                        {
                            throw new Exception("Create SkinType is fail!");

                        }
                                   response.isSuccess = true;
                response.Data=true;
                        response.Message = "Create SkinType is success";

                    
                
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


        public async Task<ApiResponse<bool>> DeleteSkinTypeAsync(string skinTypeId)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var exist = await _unitOfWork.SkinTypeRepository.GetByIdAsync(Guid.Parse(skinTypeId));
                if (exist == null)
                {
                   
                    response.Message = "Loại da không tồn tại";

                    response.isSuccess = true;
                    response.Data = false;
                    return response;
                }
                if (exist.IsDeleted)
                {

                    response.Message = "Loại da đã được xóa";

                    response.isSuccess = true;
                    response.Data = false;
                    return response;

                }
                _unitOfWork.SkinTypeRepository.SoftRemove(exist);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (isSuccess is false)
                {
                    throw new Exception("Delete Skintype is fail");
                }
                response.Data = _mapper.Map<bool>(skinTypeId);
                response.isSuccess= true;
                response.Data = true;
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




        public async Task<ApiResponse<bool>> UpdateSkinTypeAsync(CreateSkinTypeViewModel updateSkinType, string skinTypeId)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var exist = await _unitOfWork.SkinTypeRepository.GetByIdAsync(Guid.Parse(skinTypeId));

                if (exist is null)
                {
                    response.isSuccess = false;
                    response.Message = "Loại da không tồn tại";
                    response.Data = false;
                    return response;
                }

                ValidationResult validationResult = await _validatorCreateSkinType.ValidateAsync(updateSkinType);
                if (!validationResult.IsValid)
                {
                    response.isSuccess = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }

                var skinTypeList = _unitOfWork.SkinTypeRepository.Find(s => s.SkinsName == updateSkinType.SkinsName && s.Id != Guid.Parse(skinTypeId));
                var isNameExist = skinTypeList.Any();
                if (isNameExist)
                {
                    response.isSuccess = false;
                    response.Message = "Tên đã tồn tại";
                    response.Data = false;
                    return response;
                }

                var update = _mapper.Map(updateSkinType, exist);
                _unitOfWork.SkinTypeRepository.Update(update);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;

                if (!isSuccess)
                {
                    throw new Exception("Update Skintype is fail");
                }

                response.isSuccess = true;
                response.Data = true;
                response.Message = "Update Skintype is success";
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

        public async Task<ApiResponse<Pagination<SkinViewModel>>> FilterSkinTypeAsync(SkinFilterModel skinTypeFilterModel)
        {
            var response = new ApiResponse<Pagination<SkinViewModel>>();

            try
            {
                var paginationResult =await _unitOfWork.SkinTypeRepository.GetFilterAsync(
                    filter: s =>
                        (string.IsNullOrEmpty(skinTypeFilterModel.SkinTypeName) || s.SkinsName.Contains(skinTypeFilterModel.SkinTypeName)) &&
                        (string.IsNullOrEmpty(skinTypeFilterModel.Description) || s.Description.Contains(skinTypeFilterModel.Description)) &&
                        (!skinTypeFilterModel.IsDeleted.HasValue || s.IsDeleted == skinTypeFilterModel.IsDeleted.Value) &&
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

        public async Task<ApiResponse<SkinViewModel>> GetSkinTypeByIdAsync(string id)
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

