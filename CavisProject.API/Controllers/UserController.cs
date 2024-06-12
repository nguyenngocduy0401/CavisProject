using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.RegistPreniumViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/premium-packages")]
    [ApiController]
    public class UserController :ControllerBase
    {
        
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<ApiResponse<RegistPremiumViewModel>> RegistPremium(RegistPremiumViewModel registPremiumViewModel) => await _userService.RegistPremium(registPremiumViewModel);
        [HttpPut("register")]
        public async Task<ApiResponse<UpgradeToPremiumViewModel>> UpgradeToPremium(UpgradeToPremiumViewModel upgradeToPremiumViewModel)=> await _userService.UpgradeToPremium(upgradeToPremiumViewModel);
    }
}
