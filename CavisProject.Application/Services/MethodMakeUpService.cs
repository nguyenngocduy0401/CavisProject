using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.MethodViewModels;
using CavisProject.Domain.Entity;
using CavisProject.Domain.Enums;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
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
                    Url = create.Url,
                    Category = 1,
                     Status = (MethodStatusEnum)0
                };
                await _unitOfWork.MethodSkinCareRepository.AddAsync(methodSkinCare);
                bool hasCategory1 = false;
                bool hasCategory0 = false;
                if (create.SkinId != null && create.SkinId.Any())
                {
                    foreach (var skinId in create.SkinId)
                    {
                        var skin = await _unitOfWork.SkinConditionRepository.GetByIdAsync(skinId);
                        if (skin != null)
                        {
                            if (skin.Category)
                                hasCategory1 = true;
                            else
                                hasCategory0 = true;

                            var methodDetail = new MethodDetail
                            {
                                MethodId = methodSkinCare.Id,
                                SkinId = skin.Id
                            };
                            await _unitOfWork.MethodDetailRepository.AddAsync(methodDetail);
                        }
                        else
                        {
                            response.isSuccess = true;
                            response.Data = false;
                            response.Message = "Tình trạng da không tồn tại.";
                            return response;
                        }
                    }

                    if (!hasCategory1 || !hasCategory0)
                    {
                        response.isSuccess = false;
                        response.Message = "Phải có ít nhất một tinh trạng da và 1 loại da";
                        return response;
                    }
                }

                var isDetailsSaved = await _unitOfWork.SaveChangeAsync() > 0;
                if (isDetailsSaved)
                {

                    response.isSuccess = true;
                    response.Data = true;
                    response.Message = "Create Successfully";
                }
                else
                {

                    response.isSuccess = false;
                    response.Data = false;
                    response.Message = "Failed to save product details.";
                    return response;
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
                var existingMethodDetails = await _unitOfWork.MethodDetailRepository.GetAllAsync(pd => pd.MethodId == exist.Id);
                foreach (var existing in existingMethodDetails)
                {

                    await _unitOfWork.MethodDetailRepository.DeleteAsync(existing);
                }
                if (exist == null)
                {
                    response.isSuccess = true;
                    response.Data = false;
                    response.Message = "Phương pháp không tồn tại";
                    return response;
                }
                if (exist.IsDeleted)
                {

                    response.isSuccess = true;
                    response.Data = false;
                    response.Message = "Phương pháp đã được xóa";
                    return response;

                }
                _unitOfWork.MethodSkinCareRepository.SoftRemove(exist);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (isSuccess is false)
                {
                    throw new Exception("Delete Method is fail");
                }
                response.Data = _mapper.Map<bool>(id);
                response.Data = true;
                response.isSuccess = true;
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
                     (filterModel.SkinID == null || !filterModel.SkinID.Any() || s.MethodDetails.Any(pd => filterModel.SkinID.Contains(pd.SkinId.Value))) &&
                     (!filterModel.Status.HasValue || s.Status == filterModel.Status) &&
                    (!filterModel.IsDeleted.HasValue || s.IsDeleted == filterModel.IsDeleted) &&
                    s.Category == 1;

                var method = await _unitOfWork.MethodSkinCareRepository.GetFilterAsync(
                    filter: filter,
                    pageIndex: filterModel.PageIndex,
                    pageSize: filterModel.PageSize,
                    includeProperties: "User"
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
                if (update.Url != method.Url)
                {
                    method.Url = update.Url;
                }
                var existingMethodDetails = await _unitOfWork.MethodDetailRepository.GetAllAsync(pd => pd.MethodId == method.Id);
                bool hasCategory1 = false;
                bool hasCategory0 = false;

                if (update.SkinId != null && update.SkinId.Any())
                {
                    foreach (var skinId in update.SkinId)
                    {
                        var skin = await _unitOfWork.SkinConditionRepository.GetByIdAsync(skinId);
                        if (skin != null)
                        {
                            if (skin.Category)
                                hasCategory1 = true;
                            else
                                hasCategory0 = true;

                            var methodDetail = new MethodDetail
                            {
                                MethodId = method.Id,
                                SkinId = skin.Id
                            };
                            await _unitOfWork.MethodDetailRepository.AddAsync(methodDetail);
                        }
                        else
                        {
                            response.isSuccess = true;
                            response.Data = false;
                            response.Message = "Tình trạng da không tồn tại.";
                            return response;
                        }
                    }

                    if (!hasCategory1 || !hasCategory0)
                    {
                        response.isSuccess = false;
                        response.Message = "Phải có ít nhất một tinh trạng da và 1 loại da";
                        return response;
                    }
                }
                var isUpdated = await _unitOfWork.SaveChangeAsync() > 0;

                if (isUpdated)
                {
                    response.isSuccess = true;
                    response.Data = true;
                    response.Message = "Update successfully!";
                }
                else
                {
                    response.isSuccess = false;
                    response.Data = false;
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