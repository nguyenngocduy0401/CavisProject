using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Domain.Entity
{
    public class PersonalAnalyst : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public virtual ICollection<PersonalAnalystDetail>? PersonalAnalystDetails { get; set; }
        public virtual ICollection<PersonalMethodDetail>? PersonalMethodDetails { get; set; }
    }
}
