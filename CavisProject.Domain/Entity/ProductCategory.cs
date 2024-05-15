using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Domain.Entity
{
    public class ProductCategory : BaseEntity
    {
        public string? ProductCategoryName { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
