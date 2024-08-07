﻿using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.AppointmentViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        { _appointmentService = appointmentService; }
        [SwaggerOperation(Summary = "lấy danh sách các chuyên gia skincare phù hợp")]
        [HttpGet("users")]
        [Authorize()]
        public async Task<ApiResponse<Pagination<ExpertAvailabilityViewModel>>> GetAvailableExpertsAsync(AvailableExpertSkincareFilterViewModel filter) => await _appointmentService.GetAvailableExpertsAsync(filter);
        [SwaggerOperation(Summary = "lấy danh sách các cuộc hẹn")]
        [HttpGet("")]
        [Authorize()]
        public async Task<ApiResponse<Pagination<AppointmentViewModel>>> GetWeeklyScheduleAsync( FilterAppointmentByLoginViewModel filter) => await _appointmentService.GetWeeklyScheduleAsync(filter);
        
    }
}
