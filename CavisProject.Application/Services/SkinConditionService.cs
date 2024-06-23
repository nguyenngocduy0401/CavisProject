using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Domain.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Services
{
    public class SkinConditionService : ISkinConditionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateSkinTypeViewModel> _validatorCreateSkinType;
        public SkinConditionService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateSkinTypeViewModel> validatorCreateSkintype, IClaimsService claimsService)
        {
            _claimsService = claimsService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validatorCreateSkinType = validatorCreateSkintype;
        }
        public async Task<ApiResponse<bool>> CreateSkinConditionAsync(CreateSkinTypeViewModel createSkinType)
        {
            var response = new ApiResponse<bool>();
            try
            {
                FluentValidation.Results.ValidationResult validationResult = await _validatorCreateSkinType.ValidateAsync(createSkinType);
                if (!validationResult.IsValid)
                {
                    response.isSuccess = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }
                var skinType = _mapper.Map<Skin>(createSkinType);
               var skinTypeList =  _unitOfWork.SkinTypeRepository.Find(s => s.SkinsName == createSkinType.SkinsName);
                var isNameExist = skinTypeList.Any();
                if (isNameExist)
                {
                    
                    response.Message = "Tên đã tồn tại";

                    response.isSuccess = true;
                    response.Data = false;
                    return response;
                }
                
              
                   
                    
                        skinType.Category = false;
                        await _unitOfWork.SkinTypeRepository.AddAsync(skinType);
                        var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                        if (isSuccess is false)
                        {
                            throw new Exception("Create Skin Condition is fail!");
                        }
                       response.isSuccess = true;
                response.Data = true;
                        response.Message = "Create Skin Condition is success";

                    
                
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
                    response.Message = "Tình trạng da không tồn tại";

                    response.isSuccess = true;
                    response.Data = false;
                    return response;
                }
                if (exist.IsDeleted)
                {

                    response.Message = "Tình trạng da đã được xóa";

                    response.isSuccess = true;
                    response.Data = false;
                    return response;

                }
                _unitOfWork.SkinTypeRepository.SoftRemove(exist);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (isSuccess is false)
                {
                    throw new Exception("Delete Skin Condition is fail");
                }
                response.Data = _mapper.Map<bool>(skinTypeId);
                response.isSuccess = true;
                response.Data= true;
                response.Message = "Delete Skin Condition is success";
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

        public async Task<ApiResponse<Pagination<SkinViewModel>>> FilterSkinConditionAsync(SkinFilterModel skinTypeFilterModel)
        {
            var response = new ApiResponse<Pagination<SkinViewModel>>();

            try
            {
               
                var paginationResult = await _unitOfWork.SkinTypeRepository.GetFilterAsync(
                    filter: s =>
                        (string.IsNullOrEmpty(skinTypeFilterModel.SkinTypeName) || s.SkinsName.Contains(skinTypeFilterModel.SkinTypeName)) &&
                        (string.IsNullOrEmpty(skinTypeFilterModel.Description) || s.Description.Contains(skinTypeFilterModel.Description)) &&
                        (!skinTypeFilterModel.IsDeleted.HasValue || s.IsDeleted == skinTypeFilterModel.IsDeleted.Value) &&
                        s.Category == false,
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
                response.Message = "Filtered Skin Condition retrieved successfully";
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = "Error occurred while filtering Skin Condition: " + ex.Message;
            }

            return response;
        }

        public async Task<ApiResponse<bool>> UpdateSkinConditionAsync(CreateSkinTypeViewModel updateSkinType, string skinTypeId)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var exist = await _unitOfWork.SkinTypeRepository.GetByIdAsync(Guid.Parse(skinTypeId));

                if (exist is null)
                {
                    response.isSuccess = false;
                    response.Message = "Tình trạng da không tồn tại";
                    response.Data = false;
                    return response;
                }

                FluentValidation.Results.ValidationResult validationResult = await _validatorCreateSkinType.ValidateAsync(updateSkinType);
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
                    throw new Exception("Update Skin Condition is fail");
                }

                response.isSuccess = true;
                response.Data = true;
                response.Message = "Update Skin Condition is success";
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

        public async Task<ApiResponse<SkinViewModel>> GetSkinConditionByIdAsync(string id)
        {
            var response = new ApiResponse<SkinViewModel>();

            try
            {
                var skinType = await _unitOfWork.SkinTypeRepository.GetByIdAsync(Guid.Parse(id));

                if (skinType == null || skinType.Category == true)
                {
                    response.Message = "Tình trạng da không tồn tại";

                    response.isSuccess = true;
                    response.Data = null;
                    return response;
                }

                var skinTypeViewModel = _mapper.Map<SkinViewModel>(skinType);

                response.Data = skinTypeViewModel;
                response.isSuccess = true;
                response.Message = "Skin type retrieved successfully.";
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
