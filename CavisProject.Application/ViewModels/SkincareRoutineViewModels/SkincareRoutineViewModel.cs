using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.SkincareRoutineViewModels
{
    public class SkincareRoutineViewModel
    {
        public Guid Id { get; set; }
        public bool Moring { get; set; }
        public bool Night { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
