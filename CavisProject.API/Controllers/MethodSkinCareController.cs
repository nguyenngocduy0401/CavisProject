﻿using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.Repositories;
using CavisProject.Application.ViewModels.MethodViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/method-skin-care")]
   // [Authorize]
    public class MethodSkinCareController : ControllerBase
    {
       
        private readonly IMethodSkinCareService _methodSkinCareService;
        public MethodSkinCareController(IMethodSkinCareService methodSkinCareService) { _methodSkinCareService = methodSkinCareService; }
        [SwaggerOperation(Summary = "tạo thông tin phương pháp Skincare {Authorize = Admin, Staff}")]
        [HttpPost("")]
       // [Authorize(Roles = AppRole.Admin + "," + AppRole.Staff)]
        public async Task<ApiResponse<bool>> CreateMethodSkinCare([FromBody] CreateMethodViewModel model) => await _methodSkinCareService.CreateMethodSkinCareAsync(model);
        [SwaggerOperation(Summary = "tìm kiếm thông tin loại phương pháp ")]
        [HttpGet("")]
        public async Task<ApiResponse<Pagination<MethodViewModel>>> FilterMethodSkinCare(FilterMethodSkinCareViewModel filter) => await _methodSkinCareService.FilterMethodSkinCareAsync(filter);
        [SwaggerOperation(Summary = "tìm kiếm thông tin phương pháp với id ")]
        [HttpGet("{id}")]
        public async Task<ApiResponse<MethodViewModel>> GetMethodSkinCareById(string id) => await _methodSkinCareService.GetMethodSkinCareById(id);
        [SwaggerOperation(Summary = "khóa thông tin phương pháp với id {Authorize = Admin, Staff}")]
        [HttpDelete("{id}")]
       // [Authorize(Roles = AppRole.Admin + "," + AppRole.Staff)]
        public async Task<ApiResponse<bool>> DeleteMethodSkinCare(string id) => await _methodSkinCareService.DeleteMethodSkinCareAsync(id);
        [SwaggerOperation(Summary = "cập nhật thông tin loại da với id {Authorize = Admin, Staff}")]
        [HttpPut("{id}")]
       // [Authorize(Roles = AppRole.Admin + "," + AppRole.Staff)]
        public async Task<ApiResponse<bool>> UpdateMethodSkinCare([FromBody] CreateMethodViewModel model,string id) => await _methodSkinCareService.UpdateMethodSkinCareAsync(model, id);
    }
}
