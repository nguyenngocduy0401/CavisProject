using Microsoft.AspNetCore.Server.HttpSys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.UserViewModels
{
    public class UserViewModel
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public double? Wallet { get; set; }
        public bool Status { get; set; } = true;
        public double? RewardPoint { get; set; }
/*        public string? PackagePremiumId { get; set; }*/
        public bool CheckExistPersonal { get; set; }
    }
}
