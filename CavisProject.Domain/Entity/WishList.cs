using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Domain.Entity
{
    public class WishList
    {
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}
