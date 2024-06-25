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
                var scategoryList = _unitOfWork.ProductCategoryRepository.Find(p => p.ProductCategoryName == createProductCategoryViewModel.ProductCategoryName);
                var isNameExist = scategoryList.Any();
                if (isNameExist)
                {
                    response.isSuccess = false;
                    response.Message = "Danh mục sản phẩm đã tồn tại";
                    return response;
                }

                FluentValidation.Results.ValidationResult validationResult = await _validatorCreate.ValidateAsync(createProductCategoryViewModel);
                if (!validationResult.IsValid)
                {
                    response.isSuccess = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }

                var category = _mapper.Map<ProductCategory>(createProductCategoryViewModel);
                await _unitOfWork.ProductCategoryRepository.AddAsync(category);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (!isSuccess)
                {
                    throw new Exception("Tạo danh mục sản phẩm thất bại");
                }

                response.isSuccess = true;
                response.Data = true;
                response.Message = "Tạo danh mục sản phẩm thành công";
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
                    response.Message = "danh mục sản phẩm không tồn tại";

                    response.isSuccess = true;
                    response.Data = false;
                    return response;
                }
                if (exist.IsDeleted)
                {

                    response.Message = "danh mục sản phẩm đã được xóa";

                    response.isSuccess = true;
                    response.Data = false;
                    return response;

                }
                _unitOfWork.ProductCategoryRepository.SoftRemove(exist);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (isSuccess is false)
                {
                    throw new Exception("Delete category is fail");
                }
                response.Data = _mapper.Map<bool>(id);
                response.Data = true;
                response.isSuccess = true;
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

        public async Task<ApiResponse<Pagination<ProductCategoryViewModel>>> FilterProductCategoryAsync(FilterProductCategoryModel filterProductCategory)
        {
            var response = new ApiResponse<Pagination<ProductCategoryViewModel>>();
            try
            {
                var paginationResult = await _unitOfWork.ProductCategoryRepository.GetFilterAsync(
                    filter: s =>
                    (string.IsNullOrEmpty(filterProductCategory.ProductCategoryName) || s.ProductCategoryName.Contains(filterProductCategory.ProductCategoryName))&&
                    (!filterProductCategory.IsDeleted.HasValue || s.IsDeleted == filterProductCategory.IsDeleted.Value),
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

        public async Task<ApiResponse<bool>> UpdateProductCategoryAsync(CreateProductCategoryViewModel updateProductCategoryViewModel, string id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var exist = await _unitOfWork.ProductCategoryRepository.GetByIdAsync(Guid.Parse(id));

                if (exist is null)
                {
                    response.isSuccess = false;
                    response.Message = "Danh mục sản phẩm không tồn tại";
                    response.Data = false;
                    return response;
                }

                FluentValidation.Results.ValidationResult validationResult = await _validatorCreate.ValidateAsync(updateProductCategoryViewModel);
                if (!validationResult.IsValid)
                {
                    response.isSuccess = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }

                var categoryList = _unitOfWork.ProductCategoryRepository.Find(c => c.ProductCategoryName == updateProductCategoryViewModel.ProductCategoryName && c.Id != Guid.Parse(id));
                var isNameExist = categoryList.Any();
                if (isNameExist)
                {
                    response.isSuccess = false;
                    response.Message = "Tên danh mục sản phẩm đã tồn tại";
                    response.Data = false;
                    return response;
                }

                var update = _mapper.Map(updateProductCategoryViewModel, exist);
                _unitOfWork.ProductCategoryRepository.Update(update);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;

                if (!isSuccess)
                {
                    throw new Exception("Cập nhật danh mục sản phẩm thất bại");
                }

                response.isSuccess = true;
                response.Data = true;
                response.Message = "Cập nhật danh mục sản phẩm thành công";
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

        public async Task<ApiResponse<ProductCategoryViewModel>> GetProductCategoryByIdAsync(string id)
        {
            var response = new ApiResponse<ProductCategoryViewModel>();
            try
            {
                var productCategory = await _unitOfWork.ProductCategoryRepository.GetByIdAsync(Guid.Parse(id));
                if (productCategory == null)
                {
                    response.isSuccess = false;
                    response.Message = "Danh mục sản phẩm không tồn tại";
                    response.Data = null;
                    return response;
                }

                var productCategoryViewModel = _mapper.Map<ProductCategoryViewModel>(productCategory);

                response.isSuccess = true;
                response.Data = productCategoryViewModel;
                response.Message = "Lấy danh mục sản phẩm thành công";
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
