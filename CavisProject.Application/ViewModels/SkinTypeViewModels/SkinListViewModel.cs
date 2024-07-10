using CavisProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.ViewModels.SkinTypeViewModels
{
    public class SkinListViewModel
    {
        public string? SkinType { get; set; }
        public List<string>? SkinConditions { get; set; } = new List<string>();
    }
}
