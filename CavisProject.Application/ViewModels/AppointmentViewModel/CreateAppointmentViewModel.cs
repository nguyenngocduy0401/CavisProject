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

       
        public DateTime Date { get; set; }

       
        public DateTime StartTime { get; set; }

    
        public DateTime EndTime { get; set; }

 
    
        public string PhoneNumber { get; set; }

   
        public string Email { get; set; }

   
        public int Status { get; set; }
    }
}
