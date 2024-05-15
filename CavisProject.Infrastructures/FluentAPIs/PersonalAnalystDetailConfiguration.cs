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
    public class PersonalAnalystDetailConfiguration : IEntityTypeConfiguration<PersonalAnalystDetail>
    {
        public void Configure(EntityTypeBuilder<PersonalAnalystDetail> builder)
        {
            builder.HasKey(x => new { x.SkinTypeId, x.PersonalAnalystId });
            builder.HasOne(a => a.SkinType)
                .WithMany(a => a.PersonalAnalystDetails)
                .HasForeignKey(a => a.SkinTypeId);
            builder.HasOne(a => a.PersonalAnalyst)
                .WithMany(a => a.PersonalAnalystDetails)
                .HasForeignKey(a => a.PersonalAnalystId);
        }
    }
}

