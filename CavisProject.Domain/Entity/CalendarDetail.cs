using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Domain.Entity
{
    public class CalendarDetail
    {
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public Guid CalendarId { get; set; }
        [ForeignKey("CalendarId")]
        public Calendar? Calendar { get; set; }

    }
}
