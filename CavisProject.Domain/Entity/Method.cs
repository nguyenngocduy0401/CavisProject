using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Domain.Entity
{
    public class Method : BaseEntity
    {
        public string? MethodName { get; set; }
        public int Category { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }
        public string? UserId { get; set; }
        public string? Url {  get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public virtual ICollection<MethodDetail>? MethodDetails { get; set;}
        public virtual ICollection<PersonalMethodDetail>? PersonalMethodDetails { get; set;}
    }
}
