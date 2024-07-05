using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.PersonalAnalystViewModels;
using CavisProject.Application.ViewModels.PersonalImageViewModels;
using CavisProject.Application.ViewModels.ProductViewModel;
using CavisProject.Application.ViewModels.UserViewModels;
using CavisProject.Domain.Entity;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Services
{
    public class PersonalImageService : IPersonalImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentTime _currentTime;
        private readonly UserManager<User> _userManager;
        private readonly IValidator<CreatePersonalImageViewModel> _validator;
        private readonly IClaimsService _claimsService;

        public PersonalImageService(IUnitOfWork unitOfWork,IMapper mapper, ICurrentTime currentTime,
            UserManager<User> userManager, IValidator<CreatePersonalImageViewModel> validator,
            IClaimsService claimsService)
        {
            _currentTime = currentTime;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _validator = validator;
            _claimsService = claimsService;
        }

        public async Task<ApiResponse<bool>> CreatePersonalImageByLoginAsync(CreatePersonalImageViewModel createPersonalImageViewModel)
        {
            var response = new ApiResponse<bool>();
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(createPersonalImageViewModel);
                if (!validationResult.IsValid)
                {
                    response.Data = false;
                    response.isSuccess = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }
                var userId = _claimsService.GetCurrentUserId.ToString();
                if (userId == null) throw new Exception("Login  first!");
                var personalImage = _mapper.Map<PersonalImage>(createPersonalImageViewModel);
                personalImage.UserId = userId;
                await _unitOfWork.PersonalImageRepository.AddAsync(personalImage);
                var result = await _unitOfWork.SaveChangeAsync() > 0;
                if (!result) throw new Exception("Create fail!");
                response.Data = true;
                response.isSuccess = true;
                response.Message = "Successfully!";

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

        public async Task<ApiResponse<Pagination<PersonalImageViewModel>>> FilterPersonalImageByLoginAsync(FilterPersonalImageViewModel filterPersonalImageViewModel)
        {
            var response = new ApiResponse<Pagination<PersonalImageViewModel>>();
            try
            {
                var userId = _claimsService.GetCurrentUserId.ToString();
                if (userId == null) throw new Exception("Login  first!");
                var filter =  (Expression<Func<PersonalImage, bool>>)(e => e.UserId == userId &&
                (!filterPersonalImageViewModel.StartDate.HasValue || e.CreationDate >= filterPersonalImageViewModel.StartDate) &&
                (!filterPersonalImageViewModel.EndDate.HasValue || e.CreationDate <= filterPersonalImageViewModel.EndDate)
                );
                var personalImage = await _unitOfWork.PersonalImageRepository.
                    GetFilterAsync(
                    filter : filter,
                    pageIndex: filterPersonalImageViewModel.PageIndex,
                    pageSize: filterPersonalImageViewModel.PageSize);
                var personalImageViewModel = _mapper.Map<Pagination<PersonalImageViewModel>>(personalImage);
                response.Data = personalImageViewModel;
                response.isSuccess = true;
                response.Message = "Successfully!";

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
        public async Task<ApiResponse<PersonalImageViewModel>> GetPersonalImageByIdAsync(Guid id)
        {
            var response = new ApiResponse<PersonalImageViewModel>();
            try
            {
                var personalImage = await _unitOfWork.PersonalImageRepository.GetByIdAsync(id);
                if (personalImage == null) throw new Exception("Not found personalImage!");
                var personalImageViewModel = _mapper.Map<PersonalImageViewModel>(personalImage);
                response.Data = personalImageViewModel;
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

