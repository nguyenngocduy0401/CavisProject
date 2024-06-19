using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.PackagePremium;
using CavisProject.Application.ViewModels.RegistPreniumViewModel;
using CavisProject.Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Swashbuckle.AspNetCore.Annotations;

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
        [HttpPost("mine/package-premium/{id}")]
        [SwaggerOperation(Summary = "người dùng Đăng Kí Premium  {Authorize = Customer}")]
        public async Task<ApiResponse<PackagePremiumViewModel>> RegistPremium(string id) => await _userService.RegistPremiumAsync(id);
        [HttpPut("~/admin/api/v1/users/{id}/package-premium")]
        [Authorize(Roles = AppRole.Admin)]
        [SwaggerOperation(Summary = "admin Upgrade người dùng  lên premium{Authorize = Admin}")]
        public async Task<ApiResponse<UserPackageViewModel>> UpgradeToPremium(string id) => await _userService.UpgradeToPremiumAsync(id);
        [SwaggerOperation(Summary = "tìm kiếm User {Authorize = Admin}")]
        [HttpGet("")]
        //[Authorize]
        public async Task<ApiResponse<Pagination<UserViewModel>>> FilterUserAsync([FromQuery]FilterUserModel filterUserModel)
            => await _userService.FilterUserAsync(filterUserModel);
        [SwaggerOperation(Summary = "lấy thông tin User bằng đăng nhập")]
        [HttpGet("mine")]
        [Authorize]
        public async Task<ApiResponse<UserViewModel>> GetInfoByLoginAsync()
            => await _userService.GetInfoByLoginAsync();
        [SwaggerOperation(Summary = "tạo mới tài khoản (dùng cho admin để tại tài khoản cho Expert) {Authorize = Admin}")]
        [HttpPost("")]
        [Authorize]
        public async Task<ApiResponse<bool>> CreateUserAsync([FromBody] CreateUserModel createUserModel)
            => await _userService.CreateUserAsync(createUserModel);
        [SwaggerOperation(Summary = "cập mật tài khoản của User sau khi đăng nhập")]
        [HttpPut("mine/password")]
        [Authorize]
        public async Task<ApiResponse<bool>> UpdatePasswordAsync(UpdatePasswordModel updatePasswordModel)
            => await _userService.UpdatePasswordAsync(updatePasswordModel);
        [SwaggerOperation(Summary = "cập nhật tài khoản của User")]
        [HttpPut("mine")]
        [Authorize]
        public async Task<ApiResponse<bool>> UpdateUserAsync([FromBody] UpdateUserModel updateUserModel)
            => await _userService.UpdateUserAsync(updateUserModel);
        [SwaggerOperation(Summary = "Lấy thông tin của User bằng Id")]
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ApiResponse<UserViewModel>> GetUserByIdAsync(string id)
            => await _userService.GetUserByIdAsync(id);
        [SwaggerOperation(Summary = "Ban và UnBan User với quyền Admin (Không thể ban tài khoản Admin) {Authorize = Admin}")]
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ApiResponse<bool>> DeleteUserAsync(string id)
            => await _userService.DeleteUserAsync(id);
    }
}
