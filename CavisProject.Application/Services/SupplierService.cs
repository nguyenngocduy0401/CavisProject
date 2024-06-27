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

        public async Task<ApiResponse<bool>> CreateSupplierAsync(CreateSupplierViewModel createSupplierViewModel)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var supplierList = _unitOfWork.SupplierRepository.Find(s => s.SupplierName == createSupplierViewModel.SupplierName);
                var isNameExist = supplierList.Any();
                if (isNameExist)
                {
                    response.isSuccess = false;
                    response.Message = "Tên nhà cung cấp đã tồn tại";
                    response.Data = false;
                    return response;
                }

                FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(createSupplierViewModel);
                if (!validationResult.IsValid)
                {
                    response.isSuccess = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }

                var supplier = _mapper.Map<Supplier>(createSupplierViewModel);
                await _unitOfWork.SupplierRepository.AddAsync(supplier);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (!isSuccess)
                {
                    throw new Exception("Tạo nhà cung cấp thất bại");
                }

                response.isSuccess = true;
                response.Data = true;
                response.Message = "Tạo nhà cung cấp thành công";
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

        public async Task<ApiResponse<bool>> DeleteSupplierAsync(string id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var exist = await _unitOfWork.SupplierRepository.GetByIdAsync(Guid.Parse(id));
                if (exist == null)
                {
                    response.Message = "Nhà cung cấp không tồn tại";

                    response.isSuccess = true;
                    response.Data = false;
                    return response;
                }
                if (exist.IsDeleted)
                {

                     response.Message = "nhà cung cấp đã được xóa";

                    response.isSuccess = true;
                    response.Data = false;
                    return response;

                }
                _unitOfWork.SupplierRepository.SoftRemove(exist);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (isSuccess is false)
                {
                    throw new Exception("Delete Supplier is fail");
                }
                response.Data = _mapper.Map<bool>(id);
                response.isSuccess = true;
                response.Data = true;
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

        public async Task<ApiResponse<Pagination<SupplierViewModel>>> FilterSupplierAsync(FilterSupplierViewModel filterSupplierViewModel)
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
                    (string.IsNullOrEmpty(filterSupplierViewModel.Address) || s.Address.Contains(filterSupplierViewModel.Address))&&
                    (!filterSupplierViewModel.IsDeleted.HasValue || s.IsDeleted == filterSupplierViewModel.IsDeleted),
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

        public async Task<ApiResponse<bool>> UpdateSupplierAsync(CreateSupplierViewModel updateSupplierViewModel, string id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var exist = await _unitOfWork.SupplierRepository.GetByIdAsync(Guid.Parse(id));

                if (exist is null)
                {
                    response.isSuccess = false;
                    response.Message = "Nhà cung cấp không tồn tại";
                    response.Data = false;
                    return response;
                }

                FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(updateSupplierViewModel);
                if (!validationResult.IsValid)
                {
                    response.isSuccess = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }

                var supplierList = _unitOfWork.SupplierRepository.Find(s => s.SupplierName == updateSupplierViewModel.SupplierName && s.Id != Guid.Parse(id));
                var isNameExist = supplierList.Any();
                if (isNameExist)
                {
                    response.isSuccess = false;
                    response.Message = "Tên nhà cung cấp đã tồn tại";
                    response.Data = false;
                    return response;
                }

                var update = _mapper.Map(updateSupplierViewModel, exist);
                _unitOfWork.SupplierRepository.Update(update);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;

                if (!isSuccess)
                {
                    throw new Exception("Cập nhật nhà cung cấp thất bại");
                }

                response.isSuccess = true;
                response.Data = true;
                response.Message = "Cập nhật nhà cung cấp thành công";
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
                var supplier = await _unitOfWork.SupplierRepository.GetByIdAsync(Guid.Parse(id));
                if (supplier == null)
                {
                    response.isSuccess = false;
                    response.Message = "Nhà cung cấp không tồn tại";
                    response.Data = null;
                    return response;
                }

                var supplierViewModel = _mapper.Map<CreateSupplierViewModel>(supplier);

                response.isSuccess = true;
                response.Data = supplierViewModel;
                response.Message = "Lấy thông tin nhà cung cấp thành công";
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
