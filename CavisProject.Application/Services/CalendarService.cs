using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.Repositories;
using CavisProject.Application.ViewModels.AppointmentViewModel;
using CavisProject.Application.ViewModels.Calendar;
using CavisProject.Application.ViewModels.CalendarViewModel;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CavisProject.Application.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly IMapper _mapper;
        public CalendarService(IUnitOfWork unitOfWork, IClaimsService claimsService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _claimsService = claimsService;
            _mapper = mapper;
        }
        public async Task<ApiResponse<Pagination<CalendarViewModel>>> FilterCalendarAsync(CalendarFilterModel filterModel)
        {
            var response = new ApiResponse<Pagination<CalendarViewModel>>();
            try
            {
                DateTime? date = null;
                date = DateTime.Parse(filterModel.Date);
                var allSlots = await _unitOfWork.CalendarRepository.GetAllAsync();
               // var unavailableSlotIds = await _unitOfWork.CalendarRepository.GetUnAvailableCalendarAsync(date);

                var availableSlots = allSlots
                 //  .Where(calendar => !unavailableSlotIds.Contains(calendar.Id))
                   .Select(calendar => new CalendarViewModel
                   {
                       Id = calendar.Id,
                       StartTime = calendar.StartTime.HasValue
            ? $"{calendar.StartTime.Value.Hours:D2}:{calendar.StartTime.Value.Minutes:D2}"
            : null,
                       EndTime = calendar.EndTime.HasValue
            ? $"{calendar.EndTime.Value.Hours:D2}:{calendar.EndTime.Value.Minutes:D2}"
            : null,
                   })
                   .ToList();
                var totalCount = availableSlots.Count;

                var pagination = new Pagination<CalendarViewModel>
                {
                    Items = availableSlots,
                    PageIndex = filterModel.PageIndex,
                    PageSize = filterModel.PageSize,
                    TotalItemsCount = totalCount,

                };
                response.Data = pagination;
                response.isSuccess = true;
                response.Message = "Filtered  calendar retrieved successfully";
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
        public async Task<ApiResponse<CalendarViewModel>> GetCalendarByIdAsync(string id)
        {
            var response = new ApiResponse<CalendarViewModel>();

            try
            {
                var exist = await _unitOfWork.CalendarRepository.GetByIdAsync(Guid.Parse(id));
                if (exist == null) throw new Exception("Not find calendar!");
                var viewModel = _mapper.Map<CalendarViewModel>(exist);
                response.Data = viewModel;
                response.isSuccess = true;
                response.Message = "Filtered calendar retrieved successfully";
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

        public async Task<ApiResponse<bool>> SetAvailabilityAsync(List<CalendarDetailViewModel> availabilities)
        {

            var response = new ApiResponse<bool>();

            try
            {
                var userId = _claimsService.GetCurrentUserId.ToString();

                foreach (var availability in availabilities)
                {
                    foreach (var calendarId in availability.CalendarId)
                    {
                        var exists = await _unitOfWork.CalendarDetailRepository.ExistsAsync(userId, calendarId, availability.AvailabilityDate);
                        if (!exists)
                        {
                            var calendarDetail = new CalendarDetail
                            {
                                Id = Guid.NewGuid(),
                                UserId = userId,
                                CalendarId = calendarId,
                                AvailabilityDate = availability.AvailabilityDate
                            };

                            await _unitOfWork.CalendarDetailRepository.AddAsync(calendarDetail);
                        }
                    }
                }


                await _unitOfWork.SaveChangeAsync();

                response.Data = true;
                response.isSuccess = true;
                response.Message = "Availability updated successfully";
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.isSuccess = false;
                response.Message = "Error occurred while updating availability: " + ex.Message;
            }

            return response;
        }
    }
}
