using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.AppointmentViewModel;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Domain.Entity;
using CavisProject.Domain.Enums;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IValidator<CreateAppointmentViewModel> _validator;
        public AppointmentService(UserManager<User> userManager, IValidator<CreateAppointmentViewModel> validator, IUnitOfWork unitOfWork, IClaimsService claimsService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _claimsService = claimsService;
            _mapper = mapper;
            _validator = validator;
            _userManager = userManager;
        }
        public async Task<ApiResponse<List<ExpertAvailabilityViewModel>>> GetAvailableExpertsAsync(DateTime Date, TimeSpan StartTime, TimeSpan EndTime)
        {
        var response = new ApiResponse<List<ExpertAvailabilityViewModel>>();

            try
            {
                var availableExperts = await _unitOfWork.CalendarDetailRepository.GetAvailableExpertsAsync(
                    Date, StartTime,EndTime);

                var expertViewModels = _mapper.Map<List<ExpertAvailabilityViewModel>>(availableExperts);

                response.Data = expertViewModels;
                response.isSuccess = true;
                response.Message = "Available experts retrieved successfully";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.isSuccess = false;
                response.Message = "Error occurred while retrieving available experts: " + ex.Message;
            }

            return response;
        }
        public   async Task<ApiResponse<List<AppointmentViewModel>>> GetWeeklyScheduleAsync(DateTime StartDate,DateTime EndDate)
        {
            var response = new ApiResponse<List<AppointmentViewModel>>();

            try
            {
                var userId = _claimsService.GetCurrentUserId.ToString(); 
                var appointments = await _unitOfWork.AppointmentRepository.GetAppointmentsByDateRangeAsync(
                    StartDate, EndDate,userId);

                var scheduleViewModels = _mapper.Map<List<AppointmentViewModel>>(appointments);

                response.Data = scheduleViewModels;
                response.isSuccess = true;
                response.Message = "Weekly schedule retrieved successfully";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.isSuccess = false;
                response.Message = "Error occurred while retrieving weekly schedule: " + ex.Message;
            }

            return response;
        }
    }
}
