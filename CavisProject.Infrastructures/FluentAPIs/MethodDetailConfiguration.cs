using CavisProject.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Infrastructures.FluentAPIs
{
    public class MethodDetailConfiguration : IEntityTypeConfiguration<MethodDetail>
    {
        public void Configure(EntityTypeBuilder<MethodDetail> builder)
        {
            builder.HasKey(x => new { x.MethodId, x.SkinTypeId });
            builder.HasOne(a => a.Method)
                .WithMany(a => a.MethodDetails)
                .HasForeignKey(a => a.MethodId);
            builder.HasOne(a => a.SkinType)
                .WithMany(a => a.MethodDetails)
                .HasForeignKey(a => a.SkinTypeId);
        }
    }
}
