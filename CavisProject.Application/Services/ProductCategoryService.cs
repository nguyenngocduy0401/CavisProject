using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.ProductCategoryViewModel;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Domain.Entity;
using FluentValidation;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateProductCategoryViewModel> _validatorCreate;
        public ProductCategoryService(IUnitOfWork unitOfWork,IMapper mapper,IValidator<CreateProductCategoryViewModel> validator,IClaimsService claimsService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsService = claimsService;
            _validatorCreate = validator;
        }
        public async Task<ApiResponse<bool>> CreateProductCategoryAsync(CreateProductCategoryViewModel createProductCategoryViewModel)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var category = _mapper.Map<ProductCategory>(createProductCategoryViewModel);
                var scategoryList = _unitOfWork.SkinTypeRepository.Find(s => s.SkinsName == createProductCategoryViewModel.ProductCategoryName);
                var isNameExist = scategoryList.Any();
                if (isNameExist)
                {
                    throw new Exception("Product Categoory Name is exist!");
                }
                else
                {
                    FluentValidation.Results.ValidationResult validationResult = await _validatorCreate.ValidateAsync(createProductCategoryViewModel);
                    if (!validationResult.IsValid)
                    {
                        response.isSuccess = false;
                        response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                        return response;
                    }
                    else
                    {
                        await _unitOfWork.ProductCategoryRepository.AddAsync(category);
                        var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                        if (isSuccess is false)
                        {
                            throw new Exception("Create category fail");
                        }
                        response.Data = true;
                        response.Message = "Create category is success";

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

        public async Task<ApiResponse<bool>> DeleteProductCategoryAsync(string id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var exist = await _unitOfWork.ProductCategoryRepository.GetByIdAsync(Guid.Parse(id));
                if (exist == null)
                {
                    throw new Exception("No category Exit");
                }
                if (exist.IsDeleted)
                {

                    throw new Exception("category is already deleted");

                }
                _unitOfWork.ProductCategoryRepository.SoftRemove(exist);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (isSuccess is false)
                    throw new Exception("Delete category is fail");
 
                response.Data = true;
                response.isSuccess = true;
                response.Message = "Successful!";
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse<Pagination<ProductCategoryViewModel>>> FilterProductCategoryAsync(FilterProductCategoryModel filterProductCategory)
        {
            var response = new ApiResponse<Pagination<ProductCategoryViewModel>>();
            try
            {
                var paginationResult = await _unitOfWork.ProductCategoryRepository.GetFilterAsync(
                    filter: s =>
                    (string.IsNullOrEmpty(filterProductCategory.ProductCategoryName) || s.ProductCategoryName.Contains(filterProductCategory.ProductCategoryName)),
                    pageIndex: filterProductCategory.PageIndex,
                    pageSize: filterProductCategory.PageSize);
                if (paginationResult.Items == null) 
                {
                    response.Data = null;
                    response.isSuccess = true;
                    response.Message = "Không tìm thấy sản phẩm phù hợp!";
                }
                var categoryViewModel= _mapper.Map<List<ProductCategoryViewModel>>(paginationResult.Items);
                var paginationViewModel = new Pagination<ProductCategoryViewModel>
                {
                    PageIndex = paginationResult.PageIndex,
                    PageSize = paginationResult.PageSize,
                    TotalItemsCount = paginationResult.TotalItemsCount,
                    Items = categoryViewModel
                };
                response.Data = paginationViewModel;
                response.isSuccess = true;
                response.Message = "Successful!";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.isSuccess = false;
                response.Message =  ex.Message;
            }

            return response;
        }

        public async Task<ApiResponse<ProductCategoryViewModel>> GetProductCategoryByIdAsync(string id)
        {
            var response = new ApiResponse<ProductCategoryViewModel>();
            try
            {
                var productCategory = await _unitOfWork.ProductCategoryRepository.GetByIdAsync(Guid.Parse(id));
                if (productCategory == null) throw new Exception("Do not find category!");
                var categoryViewModel = _mapper.Map<ProductCategoryViewModel>(productCategory);
                response.Data = categoryViewModel;
                response.isSuccess = false;
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


        public async Task<ApiResponse<bool>> UpdateProductCategoryAsync(CreateProductCategoryViewModel UpdateProductCategoryViewModel, string id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var exist = await _unitOfWork.ProductCategoryRepository.GetByIdAsync(Guid.Parse(id));

                FluentValidation.Results.ValidationResult validationResult = await _validatorCreate.ValidateAsync(UpdateProductCategoryViewModel);
                if (validationResult.IsValid) throw new Exception(string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage)));
                else
                {
                    if (exist is null) throw new Exception("Category not found");

                    else
                    {
                        var update = _mapper.Map(UpdateProductCategoryViewModel, exist);
                        var scategoryList = _unitOfWork.SkinTypeRepository.Find(s => s.SkinsName == UpdateProductCategoryViewModel.ProductCategoryName);
                        var isNameExist = scategoryList.Any();
                        if (isNameExist)
                        {
                            throw new Exception("Tên của loại sản phẩm đã tồn tại!");
                        }
                        else
                        {
                            var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;

                            if (isSuccess is false) throw new Exception("Update Category is fail");
                        
                            response.Data = true;
                            response.isSuccess = true;
                            response.Message = "Cập nhật thành công!";
                        }

                    }
                }
            }
            catch (DbException ex)
            {
                response.Data = false;
                response.isSuccess = false;
                response.Message = ex.Message;

            }
            catch (Exception ex)
            {
                response.Data = false;
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
