using CavisProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.MethodViewModels
{
    public class CreateMethodViewModel
    {
        public string? MethodName { get; set; }
        public string? Description { get; set; }
        public string? URLImage { get; set; }
        public List<Guid>? SkinId { get; set; }

    }
}
