using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.MethodViewModels;
using CavisProject.Domain.Entity;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Services
{
    public class MethodMakeUpService : IMethodMakeUpService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateMethodViewModel> _validator;
        public MethodMakeUpService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateMethodViewModel> validator, IClaimsService claimsService)
        {
            _claimsService = claimsService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }
        public async Task<ApiResponse<bool>> CreateMethodSkinMakeUpAsync(CreateMethodViewModel create)
        {
            var response = new ApiResponse<bool>();
            try
            {
                FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(create);
                if (!validationResult.IsValid)
                {
                    response.isSuccess = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }
                var existingMethod = await _unitOfWork.MethodSkinCareRepository.GetFirstOrDefaultAsync(p => p.MethodName == create.MethodName);
                if (existingMethod != null)
                {
                    response.isSuccess = true;
                    response.Message = "Tên phương pháp đã tồn tại.";
                    response.Data = false;
                    return response;
                }
                var methodSkinCare = new Method
                {
                    MethodName = create.MethodName,
                    Description = create.Description,
                    Category = 1,
                };
                await _unitOfWork.MethodSkinCareRepository.AddAsync(methodSkinCare);
                var isMethodSaved = await _unitOfWork.SaveChangeAsync() > 0;

                if (!isMethodSaved)
                {
                    throw new Exception("Failed to save the method.");
                }
                //Xuwr li skinId
                if (create.SkinTypeId.HasValue)
                {
                    var skinType = await _unitOfWork.SkinTypeRepository.GetFirstOrDefaultAsync(s => s.Id == create.SkinTypeId && s.Category == true);
                    if (skinType != null)
                    {
                        var methodDetail = new MethodDetail
                        {
                            MethodId = methodSkinCare.Id,
                            SkinId = skinType.Id,
                            IsDeleted = false,
                        };
                        await _unitOfWork.MethodDetailRepository.AddAsync(methodDetail);
                    }
                    else
                    {
                        response.isSuccess = true;
                        response.Data = false;
                        response.Message = "Loại da không tồn tại.";
                        return response;
                    }
                }
                if (create.SkinConditionIds != null && create.SkinConditionIds.Any())
                {
                    foreach (var skinConditionId in create.SkinConditionIds)
                    {
                        var skinCondition = await _unitOfWork.SkinConditionRepository.GetByIdAsync(skinConditionId);
                        if (skinCondition != null)
                        {
                            var methodDetail = new MethodDetail
                            {
                                MethodId = methodSkinCare.Id,
                                SkinId = skinCondition.Id,
                                IsDeleted = false,
                            };
                            await _unitOfWork.MethodDetailRepository.AddAsync(methodDetail);
                        }

                    }
                }
                else
                {
                    response.isSuccess = true;
                    response.Data = false;
                    response.Message = "Tình trạng da không tồn tại.";
                    return response;
                }
                var isDetailsSaved = await _unitOfWork.SaveChangeAsync() > 0;
                if (isDetailsSaved)
                {

                    response.isSuccess = true;
                    response.Message = "Create Successfully";
                }
                else
                {

                    response.isSuccess = false;
                    response.Message = "Failed to save product details.";
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

        public async Task<ApiResponse<bool>> DeleteMethodMakeUpAsync(string id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var exist = await _unitOfWork.MethodSkinCareRepository.GetByIdAsync(Guid.Parse(id));
                if (exist == null)
                {
                    response.isSuccess = true;
                    response.Data = false;
                    response.Message = "Phương pháp không tồn tại";
                }
                if (exist.IsDeleted)
                {

                    response.isSuccess = true;
                    response.Data = false;
                    response.Message = "Phương pháp đã được xóa";

                }
                _unitOfWork.MethodSkinCareRepository.SoftRemove(exist);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (isSuccess is false)
                {
                    throw new Exception("Delete product is fail");
                }
                response.Data = _mapper.Map<bool>(id);

                response.Message = "Delete product is success";
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

        public async Task<ApiResponse<Pagination<MethodViewModel>>> FilterMethodSkinMakeUpAsync(FilterMethodSkinCareViewModel filterModel)
        {
            var response = new ApiResponse<Pagination<MethodViewModel>>();
            try
            {
                Expression<Func<Method, bool>> filter = s =>
                    (string.IsNullOrEmpty(filterModel.MethodName) || s.MethodName.Contains(filterModel.MethodName)) &&
                    (string.IsNullOrEmpty(filterModel.Description) || s.Description.Contains(filterModel.Description)) &&
                    (!filterModel.SkinConditionID.HasValue || s.MethodDetails.Any(pd => pd.SkinId == filterModel.SkinConditionID.Value && pd.Skins.Category == false)) &&
                    (!filterModel.SkinTypeId.HasValue || s.MethodDetails.Any(pd => pd.SkinId == filterModel.SkinTypeId.Value && pd.Skins.Category == true)) &&
                    s.Category == 1;

                var method = await _unitOfWork.MethodSkinCareRepository.GetFilterAsync(
                    filter: filter,
                    pageIndex: filterModel.PageIndex,
                    pageSize: filterModel.PageSize
                );

                if (method.Items.IsNullOrEmpty())
                {
                    response.Data = null;
                    response.isSuccess = true;
                    response.Message = "Không tìm thấy phương pháp phù hợp!";
                    return response;
                }

                var result = _mapper.Map<Pagination<MethodViewModel>>(method);
                response.Data = result;
                response.isSuccess = true;
                response.Message = "Successful!";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse<MethodViewModel>> GetMethodMakeUpByIdAsync(string id)
        {
            var response = new ApiResponse<MethodViewModel>();
            try
            {
                var method = await _unitOfWork.MethodSkinCareRepository.GetByIdAsync(Guid.Parse(id));
                if (method == null) throw new Exception("Not found method!");
                var methodViewModel = _mapper.Map<MethodViewModel>(method);
                response.Data = methodViewModel;
                response.isSuccess = true;
                response.Message = "Successful!";
            }
            catch (DbException ex)
            {
                response.Data = null;
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse<bool>> UpdateMethodMakeUpAsync(CreateMethodViewModel update, string id)
        {

            var response = new ApiResponse<bool>();
            try
            {
                var methodId = Guid.Parse(id);
                FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(update);
                if (!validationResult.IsValid)
                {
                    response.isSuccess = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }
                var method = await _unitOfWork.MethodSkinCareRepository.GetByIdAsync(methodId);
                if (method == null&& method.Category==1)
                {
                    response.isSuccess = true;
                    response.Data = false;
                    response.Message = "Phương pháp không tồn tại.";
                    return response;

                }
                if (!string.IsNullOrEmpty(update.MethodName) && update.MethodName != method.MethodName)
                {
                    var existingProduct = await _unitOfWork.MethodSkinCareRepository.GetFirstOrDefaultAsync(p => p.MethodName == update.MethodName && p.Id != methodId);
                    if (existingProduct != null)
                    {
                        response.isSuccess = true;
                        response.Message = "Tên phương pháp đã tồn tại.";
                        response.Data = false;
                        return response;
                    }
                    method.MethodName = update.MethodName;
                }
                if (update.Description != method.Description)
                {
                    method.Description = update.Description;
                }
                var existingMethodDetails = await _unitOfWork.MethodDetailRepository.GetAllAsync(pd => pd.MethodId == method.Id);


                if (update.SkinTypeId.HasValue || (update.SkinConditionIds != null && update.SkinConditionIds.Any()))
                {
                    foreach (var existingMethodtDetail in existingMethodDetails)
                    {
                        if ((update.SkinTypeId.HasValue && existingMethodtDetail.SkinId == update.SkinTypeId) ||
                            (update.SkinConditionIds != null && update.SkinConditionIds.Contains(existingMethodtDetail.SkinId.Value)))
                        {
                            continue;
                        }

                        existingMethodtDetail.IsDeleted = true;
                        _unitOfWork.MethodDetailRepository.Update(existingMethodtDetail);
                    }
                }
                if (update.SkinTypeId.HasValue)
                {
                    var skinType = await _unitOfWork.SkinTypeRepository.GetFirstOrDefaultAsync(s => s.Id == update.SkinTypeId.Value && s.Category == true);
                    if (skinType != null)
                    {
                        var existingMethodtDetail = existingMethodDetails.FirstOrDefault(pd => pd.SkinId == skinType.Id);
                        if (existingMethodtDetail == null)
                        {
                            var methodDetail = new MethodDetail
                            {
                                MethodId = method.Id,
                                SkinId = skinType.Id,
                                IsDeleted = false
                            };
                            await _unitOfWork.MethodDetailRepository.AddAsync(methodDetail);
                        }
                        else if (existingMethodtDetail.IsDeleted)
                        {
                            existingMethodtDetail.IsDeleted = false; // kichs hoatj laij cai cu da xoa
                            _unitOfWork.MethodDetailRepository.Update(existingMethodtDetail);
                        }
                    }
                    else
                    {
                        response.isSuccess = false;
                        response.Message = "Loại da không tồn tại.";
                        return response;
                    }
                }


                if (update.SkinConditionIds != null && update.SkinConditionIds.Any())
                {
                    foreach (var skinConditionId in update.SkinConditionIds)
                    {
                        var skinCondition = await _unitOfWork.SkinConditionRepository.GetByIdAsync(skinConditionId);
                        if (skinCondition != null)
                        {
                            var existingMethodDetail = existingMethodDetails.FirstOrDefault(pd => pd.SkinId == skinCondition.Id);
                            if (existingMethodDetail == null)
                            {
                                var methodDetail = new MethodDetail
                                {
                                    MethodId = method.Id,
                                    SkinId = skinCondition.Id,
                                    IsDeleted = false
                                };
                                await _unitOfWork.MethodDetailRepository.AddAsync(methodDetail);
                            }
                            else if (existingMethodDetail.IsDeleted)
                            {
                                existingMethodDetail.IsDeleted = false;// kichs hoatj laij cai cu da xoa
                                _unitOfWork.MethodDetailRepository.Update(existingMethodDetail);
                            }
                        }
                        else
                        {
                            response.isSuccess = false;
                            response.Message = "Tình trạng da không tồn tại.";
                            return response;
                        }
                    }
                }
                var isUpdated = await _unitOfWork.SaveChangeAsync() > 0;

                if (isUpdated)
                {
                    response.isSuccess = true;
                    response.Message = "Update successfully!";
                }
                else
                {
                    response.isSuccess = false;
                    response.Message = "Update Fail!.";
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