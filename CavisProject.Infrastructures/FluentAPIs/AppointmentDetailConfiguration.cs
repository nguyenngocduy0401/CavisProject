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
    public class AppointmentDetailConfiguration : IEntityTypeConfiguration<AppointmentDetail>
    {
        public void Configure(EntityTypeBuilder<AppointmentDetail> builder)
        {
            builder.HasKey(ad => new { ad.AppointmentId, ad.UserId });

            builder.HasOne(ad => ad.Appointment)
                .WithMany(a => a.AppointmentDetails)
                .HasForeignKey(ad => ad.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ad => ad.User)
                .WithMany(u => u.AppointmentDetails)
                .HasForeignKey(ad => ad.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
