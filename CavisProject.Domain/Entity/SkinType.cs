using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Domain.Entity
{
    public class SkinType : BaseEntity
    {
        public string? SkinTypeName { get; set; }
        public string? Description { get; set; }
        public bool Category {  get; set; }
        public virtual ICollection<MethodDetail>? MethodDetails { get; set; }
        public virtual ICollection<ProductDetail>? ProductDetails { get; set; }
        public virtual ICollection<PersonalAnalystDetail>? PersonalAnalystDetails { get; set; } 
    }
}
