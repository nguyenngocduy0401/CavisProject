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
    public class PersonalMethodDetailConfiguration : IEntityTypeConfiguration<PersonalMethodDetail>
    {
        public void Configure(EntityTypeBuilder<PersonalMethodDetail> builder)
        {
            builder.HasKey(x => new { x.PersonalAnalystId, x.MethodId });
            builder.HasOne(a => a.PersonalAnalyst)
                .WithMany(a => a.PersonalMethodDetails)
                .HasForeignKey(a => a.PersonalAnalystId);
            builder.HasOne(a => a.Method)
                .WithMany(a => a.PersonalMethodDetails)
                .HasForeignKey(a => a.MethodId);
        }
    }
}
