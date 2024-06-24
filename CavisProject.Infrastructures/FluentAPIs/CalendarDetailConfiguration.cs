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
    public class CalendarDetailConfiguration: IEntityTypeConfiguration<CalendarDetail>
    {
        public void Configure(EntityTypeBuilder<CalendarDetail> builder)
        {
            builder.HasKey(x => new { x.UserId, x.CalendarId});
            builder.HasOne(a => a.User)
                .WithMany(a => a.CalendarDetails)
                .HasForeignKey(a => a.UserId);
            builder.HasOne(a => a.Calendar)
                .WithMany(a => a.CalendarDetails)
                .HasForeignKey(a => a.CalendarId);
        }
    }
}
