using CavisProject.Application.ViewModels.PersonalAnalystDetailViewModels;
using CavisProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.PersonalAnalystViewModels
{
    public class PersonalAnalystViewModel
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        /*public virtual ICollection<PersonalAnalystDetailViewModel>? PersonalAnalystDetails { get; set; }*/
    }
}
