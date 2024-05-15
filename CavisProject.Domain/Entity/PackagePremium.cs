using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Domain.Entity
{
    public class PackagePremium : BaseEntity
    {
        public string? PackagePremiumName { get; set; }
        public double Price { get; set; }
        public double Duration { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Transaction>? Transactions { get; set; }
        public virtual ICollection<PackageDetail>? PackageDetails { get; set; }
    }
}
