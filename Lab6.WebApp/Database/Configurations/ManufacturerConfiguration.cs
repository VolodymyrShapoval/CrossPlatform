using Lab6.WebApp.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab6.WebApp.Database.Configurations
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.HasKey(mf => mf.ManufacturerCode);

            builder
                .HasMany(mf => mf.Models)
                .WithOne(m => m.Manufacturer)
                .HasForeignKey(m => m.ManufacturerCode);
        }
    }
}
