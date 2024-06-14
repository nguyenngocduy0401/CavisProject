using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.ProductViewModel;
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
        public async Task<ApiResponse<CreateProductViewModel>> CreateProduct(CreateProductViewModel createProductViewModel)
        {
            var response = new ApiResponse<CreateProductViewModel>();
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

        public Task<ApiResponse<bool>> DeleteProduct(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Pagination<CreateProductViewModel>>> Filter(FilterProductViewModel filterProductViewModel)
        {
            throw new NotImplementedException();
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
    }
}
