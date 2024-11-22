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

            // Зв'язок один до багатьох із Mechanic
            builder
                .HasOne(mos => mos.Mechanic)
                .WithMany(m => m.MechanicsOnServices)
                .HasForeignKey(mos => mos.MechanicId)
                .OnDelete(DeleteBehavior.Cascade); // Каскадне видалення

            // Зв'язок один до багатьох із ServiceBooking
            builder
                .HasOne(mos => mos.ServiceBooking)
                .WithMany(sb => sb.MechanicsOnServices)
                .HasForeignKey(mos => mos.SvcBookingId)
                .OnDelete(DeleteBehavior.Cascade); // Каскадне видалення

            // Назва таблиці в базі даних
            builder.ToTable("MechanicOnServices");
        }
    }
}
