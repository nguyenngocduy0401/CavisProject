using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Domain.Entity
{
    public class ProductDetail
    {
        public Guid? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        public Guid? SkinId { get; set; }
        [ForeignKey("SkinId")]
        public Skin? Skins { get; set; }
    }
}
