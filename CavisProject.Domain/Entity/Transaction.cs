using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Domain.Entity
{
    public class Transaction : BaseEntity
    {
        public string? Title { get; set; }
        public string? PurchaseTime { get; set; }
        public double? TotalPaid { get; set; }
        public Guid AppointmentId { get; set; }
        [ForeignKey("AppointmentId")]
        public Appointment? Appointment { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public Guid PackagePremiumId { get; set; }
        [ForeignKey("PackagePremiumId")]
        public PackagePremium? PackagePremium { get; set; }
    }
}
