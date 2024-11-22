using Lab6.WebApp.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab6.WebApp.Database.Configurations
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
        }
    }
}
