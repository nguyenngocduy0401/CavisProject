using CavisProject.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Infrastructures.FluentAPIs
{
    public class PackageDetailConfiguration : IEntityTypeConfiguration<PackageDetail>
    {
        public void Configure(EntityTypeBuilder<PackageDetail> builder)
        {
            builder.HasKey(x => new { x.UserId, x.PackagePremiumId });
            builder.HasOne(a => a.User)
                .WithMany(a => a.PackageDetails)
                .HasForeignKey(a => a.UserId);
            builder.HasOne(a => a.PackagePremium)
                .WithMany(a => a.PackageDetails)
                .HasForeignKey(a => a.PackagePremiumId);
        }
    }
}

