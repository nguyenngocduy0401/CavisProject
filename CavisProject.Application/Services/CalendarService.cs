using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
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
                var paginationResult = await _unitOfWork.CalendarRepository.GetFilterAsync(
            filter: c =>
                (!filterModel.StartTime.HasValue || c.StartTime >= filterModel.StartTime.Value) &&
                (!filterModel.EndTime.HasValue || c.EndTime <= filterModel.EndTime.Value) &&
                (!filterModel.Duration.HasValue || c.Duration == filterModel.Duration.Value),
            pageIndex: filterModel.PageIndex,
            pageSize: filterModel.PageSize
         );

                var viewModels = _mapper.Map<List<CalendarViewModel>>(paginationResult.Items);

                var paginationViewModel = new Pagination<CalendarViewModel>
                {
                    PageIndex = paginationResult.PageIndex,
                    PageSize = paginationResult.PageSize,
                    TotalItemsCount = paginationResult.TotalItemsCount,
                    Items = viewModels
                };
                response.Data = paginationViewModel;
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

        public async Task<ApiResponse<bool>> SetAvailabilityAsync(string userId, List<CalendarDetailViewModel> availabilities)
        {
            var response = new ApiResponse<bool>();

            try
            {
        
                var existingAvailabilities = await _unitOfWork.CalendarDetailRepository.GetByUserIdAsync(userId);
                await _unitOfWork.CalendarDetailRepository.DeleteRangeAsync(existingAvailabilities);

                
                var calendarDetails = availabilities.Select(a => new CalendarDetail
                {
                    UserId = userId,
                    CalendarId = a.CalendarId,
                    AvailabilityDate = a.AvailabilityDate
                }).ToList();

                await _unitOfWork.CalendarDetailRepository.AddRangeAsync(calendarDetails);
                await _unitOfWork.SaveChangeAsync();

                response.Data = true;
                response.isSuccess = true;
                response.Message = "Availability set successfully";
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
