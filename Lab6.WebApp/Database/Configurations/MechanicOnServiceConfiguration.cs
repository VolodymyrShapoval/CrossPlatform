using Lab6.WebApp.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab6.WebApp.Database.Configurations
{
    public class MechanicOnServiceConfiguration : IEntityTypeConfiguration<MechanicOnService>
    {
        public void Configure(EntityTypeBuilder<MechanicOnService> builder)
        {
            builder
                .HasOne(ms => ms.Mechanic)
                .WithMany(m => m.MechanicsOnServices)
                .HasForeignKey(ms => ms.MechanicId);

            builder
                .HasOne(ms => ms.ServiceBooking)
                .WithMany(sb => sb.MechanicsOnServices)
                .HasForeignKey(ms => ms.SvcBookingId);
        }
    }
}
