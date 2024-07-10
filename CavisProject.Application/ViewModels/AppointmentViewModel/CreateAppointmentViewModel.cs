using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.AppointmentViewModel
{
    public class CreateAppointmentViewModel
    {

        public string Title { get; set; }



        public string? Date { get; set; }
       public string CalendarId { get; set; }


        public string ExpertId { get; set; }
        public string PhoneNumber { get; set; }


        public string Email { get; set; }


      
    }
}
