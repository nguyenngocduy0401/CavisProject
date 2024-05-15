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
    public class WishListConfiguration : IEntityTypeConfiguration<WishList>
    {
        public void Configure(EntityTypeBuilder<WishList> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.UserId });
            builder.HasOne(a => a.Product)
                .WithMany(a => a.WishLists)
                .HasForeignKey(a => a.ProductId);
            builder.HasOne(a => a.User)
                .WithMany(a => a.WishLists)
                .HasForeignKey(a => a.UserId);
        }
    }
}

