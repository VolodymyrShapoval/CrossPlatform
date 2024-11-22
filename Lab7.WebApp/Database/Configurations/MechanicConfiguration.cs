using Lab7.WebApp.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Lab7.WebApp.Database.Configurations
{
    public class MechanicConfiguration : IEntityTypeConfiguration<Mechanic>
    {
        public void Configure(EntityTypeBuilder<Mechanic> builder)
        {
            builder.HasKey(m => m.MechanicId);

            builder
                .HasMany(m => m.ServiceBookings)
                .WithMany(sb => sb.Mechanics)
                .UsingEntity<MechanicOnService>(
                    ms => ms
                        .HasOne(mos => mos.ServiceBooking)
                        .WithMany(sb => sb.MechanicsOnServices)
                        .HasForeignKey(mos => mos.SvcBookingId),
                    ms => ms
                        .HasOne(mos => mos.Mechanic)
                        .WithMany(m => m.MechanicsOnServices)
                        .HasForeignKey(mos => mos.MechanicId),
                    ms =>
                    {
                        ms.HasKey(mos => new { mos.MechanicId, mos.SvcBookingId });
                        ms.ToTable("MechanicOnServices");
                    });

            builder.HasData(
                new Mechanic
                {
                    MechanicId = Guid.NewGuid(),
                    MechanicName = "Mike Johnson",
                    OtherMechanicDetails = "Specializes in engine repair"
                },
                new Mechanic
                {
                    MechanicId = Guid.NewGuid(),
                    MechanicName = "Sarah Connor",
                    OtherMechanicDetails = "Specializes in diagnostics"
                }
            );
        }
    }
}
