using Lab6.WebApp.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Lab6.WebApp.Database.Configurations
{
    public class ServiceBookingConfiguration : IEntityTypeConfiguration<ServiceBooking>
    {
        public void Configure(EntityTypeBuilder<ServiceBooking> builder)
        {
            builder.HasKey(sb => sb.SvcBookingId);

            builder
                .HasOne(sb => sb.Car)
                .WithMany(c => c.ServiceBookings)
                .HasForeignKey(sb => sb.LicenceNumber);

            builder
                .HasOne(sb => sb.Customer)
                .WithMany(c => c.ServiceBookings)
                .HasForeignKey(sb => sb.CustomerId);

            builder
                .HasMany(sb => sb.Mechanics)
                .WithMany(m => m.ServiceBookings)
                .UsingEntity<MechanicOnService>(
                    mos => mos
                        .HasOne(mos => mos.Mechanic)
                        .WithMany(m => m.MechanicsOnServices)
                        .HasForeignKey(mos => mos.MechanicId),
                    mos => mos
                        .HasOne(mos => mos.ServiceBooking)
                        .WithMany(sb => sb.MechanicsOnServices)
                        .HasForeignKey(mos => mos.SvcBookingId),
                    mos =>
                    {
                        mos.HasKey(mos => new { mos.MechanicId, mos.SvcBookingId });
                        mos.ToTable("MechanicOnServices");
                    });

            builder.HasData(
                new ServiceBooking
                {
                    SvcBookingId = Guid.NewGuid(),
                    CustomerId = Guid.Parse("e3c8be5d-0c60-4650-9b2d-830f1f0b40dc"),
                    LicenceNumber = Guid.Parse("4ef5c97f-2e2d-4a51-a614-04be77b5c65e"),
                    PaymentReceivedYn = true,
                    DatetimeOfService = DateTime.UtcNow.AddDays(-7),
                    DatetimeOfReceive = DateTime.UtcNow,
                    OtherSvcBookingDetails = "Oil change and tire rotation"
                }
            );
        }
    }
}
