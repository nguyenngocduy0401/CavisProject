using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CavisProject.Domain.Entity
{
    public class User : IdentityUser
    {
        public string? FullName { get; set; }
        public DateTime? DateOfBird { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public double? Wallet { get; set; }
        public bool Status { get; set; } = true;
        public double? RewardPoint { get; set; }
        public string? OTPEmail { get; set; }
        public DateTime? ExpireOTPEmail { get; set; }
        public virtual ICollection<Transaction>? Transactions { get; set; }
        public virtual ICollection<AppointmentDetail>? AppointmentDetails { get; set; }
        public virtual ICollection<WishList>? WishLists { get; set; } 
        public virtual ICollection<PersonalAnalyst>? PersonalAnalysts { get; set; }
        public virtual ICollection<PackageDetail>? PackageDetails { get; set; }
        public virtual ICollection<RefreshToken>? RefreshToken { get; set; }
    }
}
