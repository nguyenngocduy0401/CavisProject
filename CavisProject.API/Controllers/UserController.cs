using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.RegistPreniumViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/User")]
    [ApiController]
    public class UserController :ControllerBase
    {
        
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        [SwaggerOperation(Summary = "User Đăng Kí Premium")]
        public async Task<ApiResponse<RegistPremiumViewModel>> RegistPremium(RegistPremiumViewModel registPremiumViewModel) => await _userService.RegistPremium(registPremiumViewModel);
        [HttpPut("upgrade")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(Summary = "Upgrade user lên premium")]
        public async Task<ApiResponse<UpgradeToPremiumViewModel>> UpgradeToPremium(UpgradeToPremiumViewModel upgradeToPremiumViewModel)=> await _userService.UpgradeToPremium(upgradeToPremiumViewModel);
    }
}
