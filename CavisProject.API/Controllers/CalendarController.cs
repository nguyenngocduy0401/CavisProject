using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.Calendar;
using CavisProject.Application.ViewModels.CalendarViewModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/calendar")]
    public class CalendarController
    {
        private readonly ICalendarService _calendarService;
        public CalendarController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }
        [SwaggerOperation(Summary = "tìm kiếm thông tin lịch vấn ")]
        [HttpGet("")]
        public async Task<ApiResponse<Pagination<CalendarViewModel>>> FilterCalendarAsync(CalendarFilterModel filterModel)=> await _calendarService.FilterCalendarAsync(filterModel);
        [SwaggerOperation(Summary = "tìm kiếm thông tin lịch tư vấn bằng id ")]
        [HttpGet("{id}")]
        public async Task<ApiResponse<CalendarViewModel>> GetCalendarByIdAsync(string id)=> await _calendarService.GetCalendarByIdAsync(id);
        [SwaggerOperation(Summary = "chuyên gia chọn lịch có thể nhận tu vấn {Authorize = Expert}")]
        [HttpPost("{id}/set-availability")]
        public async Task<ApiResponse<bool>> SetAvailabilityAsync(string userId, List<CalendarDetailViewModel> availabilities)=> await _calendarService.SetAvailabilityAsync(userId, availabilities);
    }
}
