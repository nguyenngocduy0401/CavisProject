using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.Services;
using CavisProject.Application.ViewModels.AppointmentViewModel;
using CavisProject.Application.ViewModels.CalendarViewModel;
using CavisProject.Application.ViewModels.MethodViewModels;
using CavisProject.Application.ViewModels.PackagePremiumViewModels;
using CavisProject.Application.ViewModels.PersonalAnalystViewModels;
using CavisProject.Application.ViewModels.PersonalImageViewModels;
using CavisProject.Application.ViewModels.ProductViewModel;
using CavisProject.Application.ViewModels.RegistPreniumViewModel;
using CavisProject.Application.ViewModels.SkincareRoutineViewModels;
using CavisProject.Application.ViewModels.SkinTypeViewModels;
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
        public readonly ISkincareRoutineService _skincareRoutineService;
        public readonly IPersonalImageService _personalImageService;    
        private readonly IAppointmentService _appointmentService;
        private readonly ICalendarService _calendarService;
        private readonly IPersonalAnalystService _personalAnalystService;
        public UserController(ICalendarService calendarService, IUserService userService, ISkincareRoutineService skincareRoutineService,
            IPersonalImageService personalImageService, IAppointmentService appointmentService, IPersonalAnalystService personalAnalystService)
        {
            _userService = userService;
            _skincareRoutineService = skincareRoutineService;
            _personalImageService = personalImageService;
            _appointmentService = appointmentService;
            _calendarService = calendarService;
            _personalAnalystService = personalAnalystService;
        }
        [HttpPost("mine/premium-packages/{id}")]
        [SwaggerOperation(Summary = "người dùng Đăng Kí Premium  {Authorize = Customer}")]
        public async Task<ApiResponse<PackagePremiumViewModel>> RegisterPremium(string id) => await _userService.RegisterPremiumAsync(id);
        [HttpPut("{id}/premium-packages")]
        [Authorize(Roles = AppRole.Admin)]
        [SwaggerOperation(Summary = "admin Upgrade người dùng  lên premium{Authorize = Admin}")]
        public async Task<ApiResponse<UserPackageViewModel>> UpgradeToPremium(string id) => await _userService.UpgradeToPremiumAsync(id);
        [SwaggerOperation(Summary = "tìm kiếm User {Authorize = Admin}")]
        [HttpGet("")]
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
        [SwaggerOperation(Summary = "duyệt phương pháp {Authorise=Admin}}")]
        [HttpPut("mine/method/{id}")]
        [Authorize(AppRole.Admin)]
        public async Task<ApiResponse<bool>> ApproveMethodAsync(string id)=> await _userService.ApproveMethodAsync(id);

        [SwaggerOperation(Summary = "lấy thông tin dưỡng da hàng ngày")]
        [HttpGet("mine/skincare-routines")]
        [Authorize]
        public async Task<ApiResponse<SkincareRoutineViewModel>> GetSkincareRoutineByLoginAsync() => await _skincareRoutineService.GetSkincareRoutineByLogin();

        [SwaggerOperation(Summary = "tìm kiếm hình ảnh chụp của bản thân")]
        [HttpGet("mine/personal-images")]
        [Authorize]
        public async Task<ApiResponse<Pagination<PersonalImageViewModel>>> FilterPersonalImageByLoginAsync([FromQuery]FilterPersonalImageViewModel filterPersonalImageViewModel) 
            => await _personalImageService.FilterPersonalImageByLoginAsync(filterPersonalImageViewModel);
        [SwaggerOperation(Summary = "tạo hình ảnh chụp của bản thân")]
        [HttpPut("mine/personal-images")]
        [Authorize]
        public async Task<ApiResponse<bool>> CreatePersonalImageByLoginAsync(CreatePersonalImageViewModel createPersonalImageViewModel)
            => await _personalImageService.CreatePersonalImageByLoginAsync(createPersonalImageViewModel);
        [SwaggerOperation(Summary = "đặt lịch tư vấn với chuyên gia skin care")]
        [HttpPost("mine/skincare-appointments")]
        public async Task<ApiResponse<bool>> BookAppointmentAsync([FromBody] CreateAppointmentViewModel create) => await _appointmentService.BookAppointmentAsync(create);
        [SwaggerOperation(Summary = "đặt lịch tư vấn với chuyên gia make up")]
        [HttpPost("mine/makeup-appointments")]
        public async Task<ApiResponse<bool>> BookMakeUpAppointment([FromBody] CreateMakeUpAppointmentViewModel create) => await _appointmentService.BookMakeUpAppointment(create);
        [SwaggerOperation(Summary = "chuyên gia chọn lịch có thể nhận tư vấn {Authorize = Expert}")]
        [HttpPost("mine/calendars")]
        [Authorize(Roles = AppRole.ExpertSkinCare)]
        public async Task<ApiResponse<bool>> SetAvailabilityAsync([FromBody] List<CalendarDetailViewModel> availabilities) => await _calendarService.SetAvailabilityAsync(availabilities);
        [SwaggerOperation(Summary = "gợi ý sản phẩm")]
        [HttpGet("mine/personal-analysts/products")]
        [Authorize]
        public async Task<ApiResponse<Pagination<ProductViewModel>>> SuggestProductAsync([FromQuery] FilterSuggestProductModel filterSuggestProductModel) => await _personalAnalystService.SuggestProductAsync(filterSuggestProductModel);
        [SwaggerOperation(Summary = "tìm kiếm các phân tích da của cá nhân")]
        [HttpGet("mine/personal-analysts")]
        [Authorize]
        public async Task<ApiResponse<Pagination<PersonalAnalystViewModel>>> FilterPersonalAnalystAsync([FromQuery] FilterPersonalAnalystModel filterPersonalAnalystModel) =>
            await _personalAnalystService.FilterPersonalAnalystAsync(filterPersonalAnalystModel);
        [SwaggerOperation(Summary = "thêm các triệu chứng về da")]
        [HttpPost("mine/personal-analysts")]
        [Authorize]
        public async Task<ApiResponse<bool>> CreatePersonalAnalystByLoginAsync([FromBody] ListSkinPersonalModel listSkinPersonalModel) =>
            await _personalAnalystService.CreatePersonalAnalystByLoginAsync(listSkinPersonalModel);
        [SwaggerOperation(Summary = "gợi ý phương pháp (phương pháp skincare và phương pháp makeup)")]
        [HttpGet("mine/personal-analysts/methods")]
        [Authorize]
        public async Task<ApiResponse<Pagination<MethodViewModel>>> SuggestMethodAsync([FromQuery] FilterSuggestMethodModel filterSuggestMethodModel) => await _personalAnalystService.SuggestMethodMakeUpAsync(filterSuggestMethodModel);
        [SwaggerOperation(Summary = "lấy skin của người dùng khi đăng nhập")]
        [HttpGet("mine/personal-analysts/skins")]
        [Authorize]
        public async Task<ApiResponse<SkinListViewModel>> SkinListAsync() => await _personalAnalystService.SkinListByLoginAsync();
    }
}
