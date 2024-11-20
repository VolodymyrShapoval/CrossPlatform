using Lab6.WebApp.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab6.WebApp.Database.Configurations
{
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasKey(m => m.ModelCode);

            builder
                .HasOne(m => m.Manufacturer)
                .WithMany(mf => mf.Models)
                .HasForeignKey(m => m.ManufacturerCode);

            builder
                .HasMany(m => m.Cars)
                .WithOne(c => c.Model)
                .HasForeignKey(c => c.ModelCode);
        }
    }
}
