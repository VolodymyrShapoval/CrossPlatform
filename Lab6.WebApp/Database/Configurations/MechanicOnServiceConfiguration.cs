using Lab6.WebApp.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab6.WebApp.Database.Configurations
{
    public class MechanicOnServiceConfiguration : IEntityTypeConfiguration<MechanicOnService>
    {
        public void Configure(EntityTypeBuilder<MechanicOnService> builder)
        {
            builder.HasKey(mos => new { mos.MechanicId, mos.SvcBookingId });

            builder
                .HasOne(mos => mos.Mechanic)
                .WithMany(m => m.MechanicsOnServices)
                .HasForeignKey(mos => mos.MechanicId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(mos => mos.ServiceBooking)
                .WithMany(sb => sb.MechanicsOnServices)
                .HasForeignKey(mos => mos.SvcBookingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("MechanicOnServices");
        }
    }
}
