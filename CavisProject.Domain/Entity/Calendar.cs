using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Domain.Entity
{
    public class Calendar : BaseEntity
    {
        public Guid CalendarId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public double? Duration { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

    }
}
