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
                .HasMany(m => m.MechanicsOnServices)
                .WithOne(ms => ms.Mechanic)
                .HasForeignKey(ms => ms.MechanicId);
        }
    }
}
