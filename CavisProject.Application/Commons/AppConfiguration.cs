using CavisProject.Application.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Commoms
{
    public class AppConfiguration
    {
        public string DatabaseConnection { get; set; }
        public JwtOptions JwtOptions { get; set; }
    }
}
