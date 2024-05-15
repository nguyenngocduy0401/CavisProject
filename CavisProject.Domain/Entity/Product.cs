using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Domain.Entity
{
    public class Product : BaseEntity
    {
        public string? ProductName { get; set; }
        public int ClicksAmount { get; set; }
        public double ClickMoney { get; set; }
        public double TotalMoney { get; set; }
        public string? Description { get; set; }
        public string? URL { get; set; }
        public Guid? SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier? Supplier { get; set; }
        public Guid? ProductCategoryId { get; set; }
        [ForeignKey("ProductCategoryId")]
        public ProductCategory? productCategory { get; set; }
        public virtual ICollection<WishList>? WishLists { get; set; }
        public virtual ICollection<ProductDetail>? ProductDetails { get; set; }
    }
}
