using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.UserViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string? FullName { get; set; }
        public DateTime? DateOfBird { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? PackagePremiumName { get; set; }
    }
}
