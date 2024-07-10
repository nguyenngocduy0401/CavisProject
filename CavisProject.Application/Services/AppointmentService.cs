using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.Repositories;
using CavisProject.Application.ViewModels.AppointmentViewModel;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Domain.Entity;
using CavisProject.Domain.Enums;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CavisProject.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IValidator<CreateAppointmentViewModel> _validator;
        private readonly IValidator<CreateMakeUpAppointmentViewModel> _validatorMakeup;
        public AppointmentService(IValidator<CreateMakeUpAppointmentViewModel> validatorMakeup, UserManager<User> userManager, IValidator<CreateAppointmentViewModel> validator, IUnitOfWork unitOfWork, IClaimsService claimsService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _claimsService = claimsService;
            _mapper = mapper;
            _validator = validator;
            _userManager = userManager;
            _validatorMakeup = validatorMakeup;
        }
        public async Task<ApiResponse<Pagination<ExpertAvailabilityViewModel>>> GetAvailableExpertsAsync(AvailableExpertSkincareFilterViewModel filter)
        {
            var response = new ApiResponse<Pagination<ExpertAvailabilityViewModel>>();

            try
            {

                List<CalendarDetail> availableExperts;

                if (!string.IsNullOrEmpty(filter.Date) || !string.IsNullOrEmpty(filter.StartTime) || !string.IsNullOrEmpty(filter.EndTime))

                {
                    availableExperts = await _unitOfWork.CalendarDetailRepository.GetAvailableExpertsAsync(filter.Date, filter.StartTime, filter.EndTime);
                }
                else
                {
                    availableExperts = await _unitOfWork.CalendarDetailRepository.GetAllCalendarDetailsAsync();
                }

                var expertViewModels = _mapper.Map<List<ExpertAvailabilityViewModel>>(availableExperts);

                var paginatedExperts = expertViewModels
                    .Skip(filter.PageIndex - 1 * filter.PageSize)
                    .Take(filter.PageSize)
                    .ToList();

                var pagination = new Pagination<ExpertAvailabilityViewModel>
                {
                    TotalItemsCount = expertViewModels.Count,
                    PageSize = filter.PageSize,
                    PageIndex = filter.PageIndex,
                    Items = paginatedExperts
                };

                response.Data = pagination;
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

        public async Task<ApiResponse<Pagination<AppointmentViewModel>>> GetWeeklyScheduleAsync(AvailableExpertSkincareFilterViewModel filter)
        {
            var response = new ApiResponse<Pagination<AppointmentViewModel>>();

            try
            {
                DateTime? availabilityDate = null;
                TimeSpan? start = null;
                TimeSpan? end = null;
                if (!string.IsNullOrEmpty(filter.Date))
                {
                    availabilityDate = DateTime.Parse(filter.Date);
                }

                if (!string.IsNullOrEmpty(filter.StartTime))
                {
                    start = TimeSpan.Parse(filter.StartTime);
                }

                if (!string.IsNullOrEmpty(filter.EndTime))
                {
                    end = TimeSpan.Parse(filter.EndTime);
                }
                var userId = _claimsService.GetCurrentUserId.ToString();
                var appointments = await _unitOfWork.AppointmentRepository.GetAppointmentsForUserAsync(userId, availabilityDate, start, end, filter.PageIndex, filter.PageSize);


                var appointmentViewModels = appointments.Select(a => new AppointmentViewModel
                {
                    AppointmentId = a.Id,
                    Title = a.Title,
                    Date = a.Date,
                    StartTime = a.StartTime.Value.TimeOfDay,
                    EndTime = a.EndTime.Value.TimeOfDay,
                    PhoneNumber = a.PhoneNumber,
                    Email = a.Email,

                }).ToList();

                var totalCount = appointmentViewModels.Count;

                var pagination = new Pagination<AppointmentViewModel>
                {
                    Items = appointmentViewModels,
                    PageIndex = filter.PageIndex,
                    PageSize = filter.PageSize,
                    TotalItemsCount = totalCount,

                };

                response.Data = pagination;
                response.isSuccess = true;
                response.Message = "Successfully retrieved weekly schedule.";
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = "Error occurred while fetching weekly schedule: " + ex.Message;
            }

            return response;
        }
        public async Task<ApiResponse<bool>> BookAppointmentAsync(CreateAppointmentViewModel create)
        {

            var response = new ApiResponse<bool>();
            var userId = _claimsService.GetCurrentUserId.ToString();

            try
            {
                FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(create);
                if (!validationResult.IsValid)
                {
                    response.isSuccess = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }
                DateTime? date = null;
               
                  date = DateTime.Parse(create.Date);
                

                var calendarId = Guid.Parse(create.CalendarId);

                var expert = await _userManager.FindByIdAsync(create.ExpertId);
                if (expert == null && !await _userManager.IsInRoleAsync(expert, "EXPERTSKINCARE"))
                {
                    response.isSuccess = true;
                    response.Data = false;
                    response.Message = "Chuyên gia không tìm thấy!.";
                    return response;
                }
                var calendar = await _unitOfWork.CalendarRepository.GetByIdAsync(calendarId);
                if (calendar == null)
                {
                    response.isSuccess = false;
                    response.Data = false;
                    response.Message = "lịch không tìm thấy!.";
                    return response;
                }

                var isAvailable = await _unitOfWork.CalendarDetailRepository.CheckAvailabilityAsync(
                        create.ExpertId,
                        date.Value.Date,
                        calendar.StartTime.Value,
                        calendar.EndTime.Value
                    );

                if (!isAvailable)
                {
                    response.isSuccess = true;
                    response.Data = false;
                    response.Message = "Chuyên gia không rảnh vào khung giờ này.";
                    return response;
                }


                var appointment = new Appointment
                {
                    Title = create.Title,
                    Date =date.Value.Date,
                    StartTime = date.Value.Date + calendar.StartTime,
                    EndTime = date.Value.Date + calendar.EndTime,
                    PhoneNumber = create.PhoneNumber,
                    Email = create.Email,
                    CalendarId = calendarId,
                    Status = 0
                };
                await _unitOfWork.AppointmentRepository.AddAsync(appointment);
                //await _unitOfWork.SaveChangeAsync();
                var duration = (appointment.EndTime - appointment.StartTime).Value.TotalHours;
                var pricePerHour = 100000;
                var totalPaid = duration * pricePerHour;
                var transaction = new Transaction
                {
                    AppointmentId = appointment.Id,
                    PackagePremiumId = null,
                    Title = create.Title,
                    UserId = userId,
                    PurchaseTime = DateTime.UtcNow.ToLongDateString(),
                    TotalPaid = totalPaid,
                    Status = 0
                };
                await _unitOfWork.TransactionRepository.AddAsync(transaction);

                await _unitOfWork.SaveChangeAsync();

                var appointmentDetail = new AppointmentDetail
                {
                    AppointmentId = appointment.Id,
                    UserId = userId

                };
                await _unitOfWork.AppointmentDetailRepository.AddAsync(appointmentDetail);
                var appointmentDetails = new AppointmentDetail
                {
                    AppointmentId = appointment.Id,
                    UserId = create.ExpertId
                };
                await _unitOfWork.AppointmentDetailRepository.AddAsync(appointmentDetails);
                var calendarDetail = await _unitOfWork.CalendarDetailRepository
            .GetByCalendarIdAndAvailabilityDateAsync(calendarId, date.Value.Date);
                if (calendarDetail != null)
                {
                    calendarDetail.Status = CalendarStatusEnum.Booked;
                    await _unitOfWork.CalendarDetailRepository.UpdateAsync(calendarDetail);
                    await _unitOfWork.SaveChangeAsync();
                }
                else
                {
                    response.isSuccess = false;
                    response.Data = false;
                    response.Message = "Error occurred while booking appointment: ";
                    return response;
                }
                await _unitOfWork.SaveChangeAsync();

                response.isSuccess = true;
                response.Message = "Successfully booked appointment.";
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = "Error occurred while booking appointment: " + ex.Message;
            }

            return response;
        }
        public async Task<ApiResponse<bool>> BookMakeUpAppointment(CreateMakeUpAppointmentViewModel create)
        {
            var response = new ApiResponse<bool>();

            try
            {
                FluentValidation.Results.ValidationResult validationResult = await _validatorMakeup.ValidateAsync(create);
                if (!validationResult.IsValid)
                {
                    response.isSuccess = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }
                DateTime? date = null;
                TimeSpan? start = null;
                TimeSpan? end = null;
                if (!string.IsNullOrEmpty(create.Date))
                {
                    date = DateTime.Parse(create.Date);
                }

                if (!string.IsNullOrEmpty(create.StartTime))
                {
                    start = TimeSpan.Parse(create.StartTime);
                }

                if (!string.IsNullOrEmpty(create.EndTime))
                {
                    end = TimeSpan.Parse(create.EndTime);
                }
                var userId = _claimsService.GetCurrentUserId.ToString();

                var expert = await _userManager.FindByIdAsync(create.ExpertId);
                if (expert == null || !await _userManager.IsInRoleAsync(expert, "EXPERTMAKEUP"))
                {
                    response.isSuccess = true;
                    response.Data = false;
                    response.Message = "Chuyên gia không tìm thấy!.";
                    return response;
                }

                var isExpertAvailable = await _unitOfWork.AppointmentRepository.IsExpertAvailable(create.ExpertId, date.Value.Date, start, end);
                if (!isExpertAvailable)
                {
                    response.isSuccess = false;
                    response.Data = false;
                    response.Message = "Chuyên gia đã bận vào thời gian này.";
                    return response;
                }
                var appointment = new Appointment
                {
                    Title = create.Title,
                    Date =date.Value.Date,
                    StartTime = date.Value.Date + start,
                    EndTime = date.Value.Date + end,
                    PhoneNumber = create.PhoneNumber,
                    Email = create.Email,
                    Status = AppointmentStatusEnum.pending,

                };

                await _unitOfWork.AppointmentRepository.AddAsync(appointment);


                var duration = (appointment.EndTime - appointment.StartTime).Value.TotalHours;
                var pricePerHour = 100000;
                var totalPaid = duration * pricePerHour;
                var transaction = new Transaction
                {
                    AppointmentId = appointment.Id,
                    Title = appointment.Title,
                    UserId = userId,
                    PurchaseTime = DateTime.UtcNow.ToLongDateString(),
                    TotalPaid = totalPaid,
                    Status = TransactionStatusEnum.Pending 
                };
                var appointmentDetail = new AppointmentDetail
                {
                    AppointmentId = appointment.Id,
                    UserId = userId

                };
                await _unitOfWork.AppointmentDetailRepository.AddAsync(appointmentDetail);
                var appointmentDetails = new AppointmentDetail
                {
                    AppointmentId = appointment.Id,
                    UserId = create.ExpertId
                };
                await _unitOfWork.AppointmentDetailRepository.AddAsync(appointmentDetails);
                await _unitOfWork.TransactionRepository.AddAsync(transaction);

                await _unitOfWork.SaveChangeAsync();

                response.isSuccess = true;
                response.Message = "Successfully booked makeup appointment.";
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = "Error occurred while booking makeup appointment: " + ex.Message;
            }

            return response;
        }
    }
}

