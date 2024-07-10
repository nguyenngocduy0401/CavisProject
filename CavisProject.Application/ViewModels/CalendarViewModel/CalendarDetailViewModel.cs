using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.CalendarViewModel
{
    public class CalendarDetailViewModel
    {
        public List<Guid>? CalendarId { get; set; }
        public DateTime AvailabilityDate { get; set; }
    }
}
