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
    public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.SkinId });
            builder.HasOne(a => a.Product)
                .WithMany(a => a.ProductDetails)
                .HasForeignKey(a => a.ProductId);
            builder.HasOne(a => a.Skins)
                .WithMany(a => a.ProductDetails)
                .HasForeignKey(a => a.SkinId);
        }
    }
}

