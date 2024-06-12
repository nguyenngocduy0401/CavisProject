using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.PersonalAnalystDetailViewModels
{
    public class PersonalAnalystDetailViewModel
    {
        public Guid Id { get; set; }
        public string? SkinsName { get; set; }
        public string? Description { get; set; }
        public bool Category { get; set; }
    }
}
