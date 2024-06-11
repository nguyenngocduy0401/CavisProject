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
        public async Task<ApiResponse<CreateProductCategoryViewModel>> CreateProductCategory(CreateProductCategoryViewModel createProductCategoryViewModel)
        {
            var response = new ApiResponse<CreateProductCategoryViewModel>();
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
                        response.Data = _mapper.Map<CreateProductCategoryViewModel>(createProductCategoryViewModel);
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

        public async Task<ApiResponse<bool>> DeleteProductCategory(string id)
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
                {
                    throw new Exception("Delete category is fail");
                }
                response.Data = _mapper.Map<bool>(id);

                response.Message = "Delete category is success";
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

        public async Task<ApiResponse<Pagination<ProductCategoryViewModel>>> FilterProductCategory(FilterProductCategoryModel filterProductCategory)
        {
            var response = new ApiResponse<Pagination<ProductCategoryViewModel>>();
            try
            {
                var paginationResult = await _unitOfWork.ProductCategoryRepository.GetFilterAsync(
                    filter: s =>
                    (string.IsNullOrEmpty(filterProductCategory.ProductCategoryName) || s.ProductCategoryName.Contains(filterProductCategory.ProductCategoryName)),
                    pageIndex: filterProductCategory.PageIndex,
                    pageSize: filterProductCategory.PageSize); ;
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
                response.Message = "Filter product category retrived successfully";
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = "Error occurred while filtering skin types: " + ex.Message;
            }

            return response;
        }

        public async Task<ApiResponse<CreateProductCategoryViewModel>> UppdateProductCategory(CreateProductCategoryViewModel UpdateProductCategoryViewModel, string id)
        {
            var response = new ApiResponse<CreateProductCategoryViewModel>();
            try
            {
                var exist = await _unitOfWork.ProductCategoryRepository.GetByIdAsync(Guid.Parse(id));

                FluentValidation.Results.ValidationResult validationResult = await _validatorCreate.ValidateAsync(UpdateProductCategoryViewModel);
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
                        throw new Exception("Category not found");

                    }
                    else
                    {
                        var update = _mapper.Map(UpdateProductCategoryViewModel, exist);
                        var scategoryList = _unitOfWork.SkinTypeRepository.Find(s => s.SkinsName == UpdateProductCategoryViewModel.ProductCategoryName);
                        var isNameExist = scategoryList.Any();
                        if (isNameExist)
                        {
                            throw new Exception("Product Categoory Name is exist!");
                        }
                        else
                        {
                            var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;

                            if (isSuccess is false)
                            {
                                throw new Exception("Update Category is fail");
                            }
                            response.Data = _mapper.Map<CreateProductCategoryViewModel>(id);

                            response.Message = "Update Category is success";
                        }

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
