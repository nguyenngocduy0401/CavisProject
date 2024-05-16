using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Commons
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public bool isSuccess { get; set; } = true;
        public string? Message { get; set; }
    }
}
