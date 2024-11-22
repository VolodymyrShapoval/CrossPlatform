using Lab6.WebApp.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        }
    }
}
