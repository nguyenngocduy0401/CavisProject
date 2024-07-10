using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.AppointmentViewModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/appointment")]
    public class AppointmentController:ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        { _appointmentService = appointmentService; }
        [SwaggerOperation(Summary = "lấy thông tin các chuyên gia phù hợp")]
        [HttpGet("mine/users")]
         public async  Task<ApiResponse<Pagination<ExpertAvailabilityViewModel>>> GetAvailableExpertsAsync(AvailableExpertSkincareFilterViewModel filter)=> await _appointmentService.GetAvailableExpertsAsync(filter);
        [SwaggerOperation(Summary = "lấy danh sách các cuộc hẹn")]
        [HttpGet("mine")]
        public async Task<ApiResponse<Pagination<AppointmentViewModel>>> GetWeeklyScheduleAsync( AvailableExpertSkincareFilterViewModel filter) => await _appointmentService.GetWeeklyScheduleAsync(filter);
        [SwaggerOperation(Summary = "đặt lịch tư vấn với chuyên gia skin care")]
        [HttpPost("mine")]
        public async Task<ApiResponse<bool>> BookAppointmentAsync([FromBody]CreateAppointmentViewModel create)=> await _appointmentService.BookAppointmentAsync(create);
    }
}
