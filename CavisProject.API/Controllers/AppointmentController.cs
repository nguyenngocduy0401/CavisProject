using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.AppointmentViewModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/appointments")]
    public class AppointmentController:ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        { _appointmentService = appointmentService; }
       
        [SwaggerOperation(Summary = "lấy danh sách các cuộc hẹn")]
        [HttpGet("")]
        public async Task<ApiResponse<Pagination<AppointmentViewModel>>> GetWeeklyScheduleAsync( AvailableExpertSkincareFilterViewModel filter) => await _appointmentService.GetWeeklyScheduleAsync(filter);
        
    }
}
