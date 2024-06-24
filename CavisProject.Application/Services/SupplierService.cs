using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Application.ViewModels.SupplierViewModel;
using CavisProject.Domain.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateSupplierViewModel> _validator;
        public SupplierService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateSupplierViewModel> validator, IClaimsService claimsService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<ApiResponse<CreateSupplierViewModel>> CreateSupplier(CreateSupplierViewModel createSupplierViewModel)
        {

            var response = new ApiResponse<CreateSupplierViewModel>();
            try
            {
                var supplier = _mapper.Map<Supplier>(createSupplierViewModel);
                var supplierList = _unitOfWork.SupplierRepository.Find(s => s.SupplierName == createSupplierViewModel.SupplierName);
                var isNameExist = supplierList.Any();
                if (isNameExist)
                {
                    throw new Exception("Supplier Name is exist!");
                }
                else
                {
                    FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(createSupplierViewModel);
                    if (!validationResult.IsValid)
                    {
                        response.isSuccess = false;
                        response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                        return response;
                    }
                    else
                    {
                   
                        await _unitOfWork.SupplierRepository.AddAsync(supplier);
                        var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                        if (isSuccess is false)
                        {
                            throw new Exception("Create Supplier is fail!");
                        }
                        response.Data = _mapper.Map<CreateSupplierViewModel>(createSupplierViewModel);
                        response.Message = "Create Supplier is success";

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

        public async Task<ApiResponse<bool>> DeleteSupplier(string id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var exist = await _unitOfWork.SupplierRepository.GetByIdAsync(Guid.Parse(id));
                if (exist == null)
                {
                    throw new Exception("No Supplier Exit");
                }
                if (exist.IsDeleted)
                {

                    throw new Exception("Supplier is already deleted");

                }
                _unitOfWork.SupplierRepository.SoftRemove(exist);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (isSuccess is false)
                {
                    throw new Exception("Delete Supplier is fail");
                }
                response.Data = _mapper.Map<bool>(id);

                response.Message = "Delete Supplier is success";
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

        public async Task<ApiResponse<Pagination<SupplierViewModel>>> FilterSupplier(FilterSupplierViewModel filterSupplierViewModel)
        {
            var response = new ApiResponse<Pagination<SupplierViewModel>>();

            try
            {
                var paginationResult = await _unitOfWork.SupplierRepository.GetFilterAsync(
                      filter: s =>
                      (string.IsNullOrEmpty(filterSupplierViewModel.SupplierName) || s.SupplierName.Contains(filterSupplierViewModel.SupplierName)) &&
                    (string.IsNullOrEmpty(filterSupplierViewModel.PhoneNumber) || s.PhoneNumber.Contains(filterSupplierViewModel.PhoneNumber)) &&
                    (string.IsNullOrEmpty(filterSupplierViewModel.Email) || s.Email.Contains(filterSupplierViewModel.Email)) &&
                   (!filterSupplierViewModel.Status.HasValue || s.Status == filterSupplierViewModel.Status) &&
                    (string.IsNullOrEmpty(filterSupplierViewModel.Address) || s.Address.Contains(filterSupplierViewModel.Address)),
                    pageIndex: filterSupplierViewModel.PageIndex,
                    pageSize: filterSupplierViewModel.PageSize
                );
                var supplierViewModel = _mapper.Map<List<SupplierViewModel>>(paginationResult.Items);
                var paginationViewModel = new Pagination<SupplierViewModel>
                {
                    PageIndex = paginationResult.PageIndex,
                    PageSize = paginationResult.PageSize,
                    TotalItemsCount = paginationResult.TotalItemsCount,
                    Items = supplierViewModel
                };
                response.Data = paginationViewModel;
                response.isSuccess = true;
                response.Message = "Filtered suppliers retrieved successfully";
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = "Error occurred while filtering suppliers: " + ex.Message;
            }

            return response;
        }

        public async Task<ApiResponse<CreateSupplierViewModel>> UppdateSupplier(CreateSupplierViewModel updateSupplierViewModel, string id)
        {
            var response = new ApiResponse<CreateSupplierViewModel>();
            try
            {
                var exist = await _unitOfWork.SupplierRepository.GetByIdAsync(Guid.Parse(id));

                FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(updateSupplierViewModel);
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
                        throw new Exception("Supplier not found");

                    }
                    else
                    {
                        var update = _mapper.Map(updateSupplierViewModel, exist);
                        var supplierList = _unitOfWork.SupplierRepository.Find(s => s.SupplierName == update.SupplierName);
                        var isNameExist = supplierList.Any();
                        if (isNameExist)
                        {
                            throw new Exception("Supplier Name is exist!");
                        }
                        var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;

                        if (isSuccess is false)
                        {
                            throw new Exception("Update Supplier is fail");
                        }
                        response.Data = _mapper.Map<CreateSupplierViewModel>(id);

                        response.Message = "Update Supplier is success";
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
        public async Task<ApiResponse<CreateSupplierViewModel>> GetSupplierByIdAsync(string id)
        {
            var response = new ApiResponse<CreateSupplierViewModel>();
            try
            {
                var supplier = await _unitOfWork.PackagePremiumRepository.GetByIdAsync(Guid.Parse(id));
                if (supplier == null)
                {
                    throw new Exception("Không tìm thấy !");
                }

                var supplierViewModel = _mapper.Map<CreateSupplierViewModel>(supplier);

                response.isSuccess = true;
                response.Data = supplierViewModel;
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
