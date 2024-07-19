using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.Calendar;
using CavisProject.Application.ViewModels.CalendarViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/calendars")]
    [Authorize]
    public class CalendarController
    {
        private readonly ICalendarService _calendarService;
        public CalendarController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }
        [SwaggerOperation(Summary = "tìm kiếm thông tin lịch tư vấn theo ngày ")]
        [HttpGet("")]

        public async Task<ApiResponse<Pagination<CalendarViewModel>>> FilterCalendarAsync(CalendarFilterModel filterModel)=> await _calendarService.FilterCalendarAsync(filterModel);
        [SwaggerOperation(Summary = "tìm kiếm thông tin lịch tư vấn bằng id ")]
        [HttpGet("{id}")]
        public async Task<ApiResponse<CalendarViewModel>> GetCalendarByIdAsync(string id)=> await _calendarService.GetCalendarByIdAsync(id);
        
    }
}
