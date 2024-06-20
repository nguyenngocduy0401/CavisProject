using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.ProductViewModel;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Domain.Entity;
using FluentValidation;
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
        public async Task<ApiResponse<bool>> CreateProduct(CreateProductViewModel createProductViewModel)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var product = _mapper.Map<Product>(createProductViewModel);

                FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(createProductViewModel);
                if (!validationResult.IsValid)
                {
                    response.isSuccess = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }
/*
                var currentID = _claimsService.GetCurrentUserId;
                if (currentID == Guid.Empty)
                {
                    response.isSuccess = false;
                    response.Message = "Register please";
                    return response;
                }*/

                var supplierExists = await _unitOfWork.SupplierRepository.GetByIdAsync(createProductViewModel.SupplierId.Value);
                if (supplierExists == null)
                {
                    response.isSuccess = false;
                    response.Message = "Supplier does not exist.";
                    return response;
                }

  
                var productCategoryExists = await _unitOfWork.ProductCategoryRepository.GetByIdAsync(createProductViewModel.ProductCategoryId.Value);
                if (productCategoryExists == null)
                {
                    response.isSuccess = false;
                    response.Message = "Product category does not exist.";
                    return response;
                }

                if (createProductViewModel.SkinIds != null && createProductViewModel.SkinIds.Any())
                {
                    foreach (var skinId in createProductViewModel.SkinIds)
                    {
                        var skinExists = await _unitOfWork.SkinTypeRepository.GetByIdAsync(skinId);
                        if (skinExists == null)
                        {
                            response.isSuccess = false;
                            response.Message = "Skin with ID " + skinId + " does not exist.";
                            return response;
                        }
                    }

                    product.ProductDetails = createProductViewModel.SkinIds.Select(skinId => new ProductDetail
                    {
                        SkinId = skinId,
                        Product = product
                    }).ToList();
                }

                await _unitOfWork.ProductRepository.AddAsync(product);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;

                if (isSuccess)
                {
                    response.isSuccess = true;
                    response.Message = "Create Successfully";
                }
                else
                {
                    response.isSuccess = false;
                    response.Message = "Failed to create product.";
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

        public async Task<ApiResponse<bool>> DeleteProduct(string id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var exist = await _unitOfWork.ProductRepository.GetByIdAsync(Guid.Parse(id));
                if (exist == null)
                {
                    response.isSuccess = true;
                    response.Data=false;
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
        public async Task<ApiResponse<Pagination<ProductViewModel>>> Filter(FilterProductViewModel filterProductViewModel)
        {
            var response = new ApiResponse<Pagination<ProductViewModel>>();

            try
            {
                // Tạo biểu thức lọc
                Expression<Func<Product, bool>> filter = s =>
                    (string.IsNullOrEmpty(filterProductViewModel.ProductName) || s.ProductName.Contains(filterProductViewModel.ProductName)) &&
                    (string.IsNullOrEmpty(filterProductViewModel.Description) || s.Description.Contains(filterProductViewModel.Description)) &&
                    (filterProductViewModel.SupplierId == Guid.Empty || s.SupplierId == filterProductViewModel.SupplierId) &&
                    (filterProductViewModel.ProductCategoryId == Guid.Empty || s.ProductCategoryId == filterProductViewModel.ProductCategoryId) &&
                    (!filterProductViewModel.SkinConditionID.HasValue || s.ProductDetails.Any(pd => pd.SkinId == filterProductViewModel.SkinConditionID)) &&
                    (!filterProductViewModel.SkinTypeId.HasValue || s.ProductDetails.Any(pd => pd.SkinId == filterProductViewModel.SkinTypeId));

                var paginationResult = await _unitOfWork.ProductRepository.GetFilterAsync(
                    filter: filter,
                    pageIndex: filterProductViewModel.PageIndex,
                    pageSize: filterProductViewModel.PageSize
                );

                var productViewModels = _mapper.Map<List<ProductViewModel>>(paginationResult.Items);

                var paginationViewModel = new Pagination<ProductViewModel>
                {
                    PageIndex = paginationResult.PageIndex,
                    PageSize = paginationResult.PageSize,
                    TotalItemsCount = paginationResult.TotalItemsCount,
                    Items = productViewModels,
                };

                response.Data = paginationViewModel;
                response.isSuccess = true;
                response.Message = "Filtered Product retrieved successfully";
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = "Error occurred while filtering Product: " + ex.Message;
            }

            return response;
        }
        public Task<ApiResponse<CreateProductViewModel>> GetProductDetail(string id)
        {
            throw new NotImplementedException();
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
        public async Task<ApiResponse<CreateProductViewModel>> UpdateProduct(CreateProductViewModel createProductViewModel, string id)
        {
            var response = new ApiResponse<CreateProductViewModel>();
            try
            {
                var exist = await _unitOfWork.ProductRepository.GetByIdAsync(Guid.Parse(id));

                
                    if (exist is null)
                    {
                        throw new Exception("Skintype not found");

                    }
                    else
                    {
                        var update = _mapper.Map(createProductViewModel, exist);
                    FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(createProductViewModel);
                    if (!validationResult.IsValid)
                    {
                        response.isSuccess = false;
                        response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                        return response;
                    }
                    var productList = _unitOfWork.ProductRepository.Find(s => s.ProductName == update.ProductName);
                        var isNameExist = productList.Any();
                        if (isNameExist)
                        {
                        response.isSuccess = true;
                        response.Data = null;
                        response.Message = "tên đã tồn tại";
                        }
                        var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;

                        if (isSuccess is false)
                        {
                            throw new Exception("Update product is fail");
                        }
                        response.Data = _mapper.Map<CreateProductViewModel>(id);

                        response.Message = "Update Product is success";
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
