using Lab6.WebApp.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

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

            builder.HasData(
                new Model
                {
                    ModelCode = Guid.Parse("f6b97f25-49ef-42c4-a2c6-7e4a5581e7a9"),
                    ManufacturerCode = Guid.Parse("d56a518d-346d-4a5c-bb2e-b0da1e634e40"),
                    ModelName = "Corolla",
                    OtherModelDetails = "A compact sedan"
                }
            );
        }
    }
}
