﻿using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.ProductViewModel;

using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Domain.Entity;
using CavisProject.Domain.Enums;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateProductViewModel> _validator;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateProductViewModel> validator, IClaimsService claimsService)
        {
            _claimsService = claimsService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }
        public async Task<ApiResponse<bool>> CreateProductAsync(CreateProductViewModel createProductViewModel)
        {
            var response = new ApiResponse<bool>();
            try
            {
                FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(createProductViewModel);
                if (!validationResult.IsValid)
                {
                    response.isSuccess = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }
                var existingProduct = await _unitOfWork.ProductRepository.GetFirstOrDefaultAsync(p => p.ProductName == createProductViewModel.ProductName);
                if (existingProduct != null)
                {
                    response.isSuccess = true;
                    response.Data = false;
                    response.Message = "Tên sản phẩm đã tồn tại.";
                    return response;
                }
                if (!Enum.IsDefined(typeof(ProductStatusEnum), createProductViewModel.Status))
                {
                    response.isSuccess = true;
                    response.Data = false;
                    response.Message = "Loại sản phâm không tồn tại.";
                    return response;
                }
                var product = new Product
                {
                    ProductName = createProductViewModel.ProductName,
                    ClickMoney = createProductViewModel.ClickMoney,
                    Description = createProductViewModel.Description,
                    URL = createProductViewModel.URL,
                    SupplierId = createProductViewModel.SupplierId,
                    ProductCategoryId = createProductViewModel.ProductCategoryId,
                    Price = createProductViewModel.Price,
                    Status = (ProductStatusEnum)createProductViewModel.Status,
                    URLImage = createProductViewModel.URLImage,
                };

                var supplierExists = await _unitOfWork.SupplierRepository.GetByIdAsync(createProductViewModel.SupplierId.Value);
                if (supplierExists == null)
                {
                    response.isSuccess = true;
                    response.Data = false;
                    response.Message = "Nhà cung cấp không tồn tại.";
                    return response;
                }

                var productCategoryExists = await _unitOfWork.ProductCategoryRepository.GetByIdAsync(createProductViewModel.ProductCategoryId.Value);
                if (productCategoryExists == null)
                {
                    response.isSuccess = true;
                    response.Data = false;
                    response.Message = "Phân loại sản phẩm không tồn tại.";
                    return response;
                }


                await _unitOfWork.ProductRepository.AddAsync(product);
                bool hasCategory1 = false;
                bool hasCategory0 = false;

                if (createProductViewModel.SkinId != null && createProductViewModel.SkinId.Any())
                {
                    foreach (var skinId in createProductViewModel.SkinId)
                    {
                        var skin = await _unitOfWork.SkinConditionRepository.GetByIdAsync(skinId);
                        if (skin != null)
                        {
                            if (skin.Category)
                                hasCategory1 = true;
                            else
                                hasCategory0 = true;

                            var productDetail = new ProductDetail
                            {
                                ProductId = product.Id,
                                SkinId = skin.Id
                            };
                            await _unitOfWork.ProductDetailRepository.AddAsync(productDetail);
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
                        response.isSuccess = true;
                        response.Message = "Phải có ít nhất một tinh trạng da và 1 loại da";
                        response.Data = false;
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
        public async Task<ApiResponse<bool>> DeleteProductAsync(string id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var exist = await _unitOfWork.ProductRepository.GetByIdAsync(Guid.Parse(id));
                var existingProductDetails = await _unitOfWork.ProductDetailRepository.GetAllAsync(pd => pd.ProductId == exist.Id);
                foreach (var existingProductDetail in existingProductDetails)
                {

                    await _unitOfWork.ProductDetailRepository.Delete(existingProductDetail);
                }
                if (exist == null)
                {
                    response.isSuccess = true;
                    response.Data = false;
                    response.Message = "Sản phẩm không tồn tại";
                }
                if (exist.IsDeleted)
                {

                    response.isSuccess = true;
                    response.Data = false;
                    response.Message = "Sản phẩm đã được xóa";

                }
                _unitOfWork.ProductRepository.SoftRemove(exist);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (isSuccess is false)
                {
                    throw new Exception("Delete product is fail");
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
        public async Task<ApiResponse<Pagination<ProductViewModel>>> FilterProductAsync(FilterProductViewModel filterProductViewModel)
        {
            var response = new ApiResponse<Pagination<ProductViewModel>>();
            try
            {
                Expression<Func<Product, bool>> filter = s =>
                    (string.IsNullOrEmpty(filterProductViewModel.ProductName) || s.ProductName.Contains(filterProductViewModel.ProductName)) &&
                    (string.IsNullOrEmpty(filterProductViewModel.Description) || s.Description.Contains(filterProductViewModel.Description)) &&
                  (!filterProductViewModel.SupplierId.HasValue || s.SupplierId == filterProductViewModel.SupplierId.Value) &&
                (!filterProductViewModel.SupplierId.HasValue || s.SupplierId == filterProductViewModel.SupplierId.Value) &&
            (!filterProductViewModel.ProductCategoryId.HasValue || s.ProductCategoryId == filterProductViewModel.ProductCategoryId.Value) &&
                 (!filterProductViewModel.Status.HasValue || s.Status == filterProductViewModel.Status.Value) &&
            (filterProductViewModel.SkinId == null || !filterProductViewModel.SkinId.Any() || s.ProductDetails.Any(pd => filterProductViewModel.SkinId.Contains(pd.SkinId.Value))) &&
                (!filterProductViewModel.IsDeleted.HasValue || s.IsDeleted == filterProductViewModel.IsDeleted);
                var products = await _unitOfWork.ProductRepository.GetFilterAsync(
                    filter: filter,
                    pageIndex: filterProductViewModel.PageIndex,
                    pageSize: filterProductViewModel.PageSize,
                    includeProperties: "Supplier"
                );
                if (products.Items.IsNullOrEmpty())
                {
                    response.Data = null;
                    response.isSuccess = true;
                    response.Message = "Không tìm thấy sản phẩm phù hợp!";
                    return response;
                }
                var result = _mapper.Map<Pagination<ProductViewModel>>(products);

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

        public async Task<ApiResponse<ProductViewModel>> GetProductDetailByIdAsync(string productId)
        {
            var response = new ApiResponse<ProductViewModel>();
            try
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(Guid.Parse(productId));
                if (product == null) throw new Exception("Not found product!");
                var productViewModel = _mapper.Map<ProductViewModel>(product);
                response.Data = productViewModel;
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
        public async Task<ApiResponse<bool>> UpdateProductAsync(CreateProductViewModel updateProductViewModel, string id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var productId = Guid.Parse(id);
                FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(updateProductViewModel);
                if (!validationResult.IsValid)
                {
                    response.isSuccess = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(productId);
                if (product == null)
                {
                    response.isSuccess = true;
                    response.Data = false;
                    response.Message = "Sản phẩm không tồn tại.";
                    return response;

                }
                if (!Enum.IsDefined(typeof(ProductStatusEnum), updateProductViewModel.Status))
                {
                    response.isSuccess = false;
                    response.Data = false;
                    response.Message = "Giá trị của Status không hợp lệ.";
                    return response;
                }

                if (!string.IsNullOrEmpty(updateProductViewModel.ProductName) && updateProductViewModel.ProductName != product.ProductName)
                {
                    var existingProduct = await _unitOfWork.ProductRepository.GetFirstOrDefaultAsync(p => p.ProductName == updateProductViewModel.ProductName && p.Id != productId);
                    if (existingProduct != null)
                    {
                        response.isSuccess = true;
                        response.Message = "Tên sản phẩm đã tồn tại.";
                        response.Data = false;
                        return response;
                    }
                    product.ProductName = updateProductViewModel.ProductName;
                }
                if (updateProductViewModel.Price != 0)
                {
                    product.Price = updateProductViewModel.Price;
                }
                if (updateProductViewModel.ClickMoney != 0)
                    product.ClickMoney = updateProductViewModel.ClickMoney;

                if (!string.IsNullOrEmpty(updateProductViewModel.Description))
                    product.Description = updateProductViewModel.Description;

                if (!string.IsNullOrEmpty(updateProductViewModel.URL))
                    product.URL = updateProductViewModel.URL;
                if (updateProductViewModel.Status != null)
                {
                    product.Status = (ProductStatusEnum)updateProductViewModel.Status;
                }
                if(updateProductViewModel.URLImage != null)
                {
                    product.URLImage = updateProductViewModel.URLImage;
                }
                if (updateProductViewModel.SupplierId.HasValue)
                {
                    var supplierExists = await _unitOfWork.SupplierRepository.GetByIdAsync(updateProductViewModel.SupplierId.Value);
                    if (supplierExists == null)
                    {
                        response.isSuccess = true;
                        response.Message = "Nhà cung cấp không tồn tại.";
                        response.Data = false;
                        return response;
                    }
                    product.SupplierId = updateProductViewModel.SupplierId.Value;
                }

                var existingProductDetails = await _unitOfWork.ProductDetailRepository.GetAllAsync(pd => pd.ProductId == product.Id);
                foreach (var existingProductDetail in existingProductDetails)
                {
                    await _unitOfWork.ProductDetailRepository.Delete(existingProductDetail);
                }

                bool hasCategory1 = false;
                bool hasCategory0 = false;

                if (updateProductViewModel.SkinId != null && updateProductViewModel.SkinId.Any())
                {
                    foreach (var skinId in updateProductViewModel.SkinId)
                    {
                        var skin = await _unitOfWork.SkinConditionRepository.GetByIdAsync(skinId);
                        if (skin != null)
                        {
                            if (skin.Category)
                                hasCategory1 = true;
                            else
                                hasCategory0 = true;

                            var productDetail = new ProductDetail
                            {
                                ProductId = product.Id,
                                SkinId = skin.Id
                            };
                            await _unitOfWork.ProductDetailRepository.AddAsync(productDetail);
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
                        response.Message = "Danh sách SkinId phải có ít nhất một SkinId với Category = 1 và một SkinId với Category = 0.";
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
