using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("")]
        public async Task<ApiResponse<Pagination<UserViewModel>>> FilterUserAsync([FromQuery]FilterUserModel filterUserModel)
            => await _userService.FilterUserAsync(filterUserModel);
        [HttpGet("mine")]
        public async Task<ApiResponse<UserViewModel>> GetInfoByLoginAsync()
            => await _userService.GetInfoByLoginAsync();
        [HttpPost("")]
        public async Task<ApiResponse<bool>> CreateUserAsync([FromBody] CreateUserModel createUserModel)
            => await _userService.CreateUserAsync(createUserModel);
        [HttpPut("mine/password")]
        public async Task<ApiResponse<bool>> UpdatePasswordAsync(UpdatePasswordModel updatePasswordModel)
            => await _userService.UpdatePasswordAsync(updatePasswordModel);
        [HttpPut("mine")]
        public async Task<ApiResponse<bool>> UpdateUserAsync([FromBody] UpdateUserModel updateUserModel)
            => await _userService.UpdateUserAsync(updateUserModel);
        [HttpGet("{id}")]
        public async Task<ApiResponse<UserViewModel>> GetUserByIdAsync(string id)
            => await _userService.GetUserByIdAsync(id);
        [HttpDelete("{id}")]
        public async Task<ApiResponse<bool>> DeleteUserAsync(string id)
            => await _userService.DeleteUserAsync(id);
    }
}
