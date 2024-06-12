using CavisProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.UserViewModels
{
    public class CreateUserModel
    {
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public DateTime? DateOfBird { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Roles { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirm { get; set; }
    }
}
