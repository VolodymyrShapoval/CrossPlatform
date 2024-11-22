using Lab6.WebApp.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Lab6.WebApp.Database.Configurations
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.HasKey(mf => mf.ManufacturerCode);

            //builder
            //    .HasMany(mf => mf.Models)
            //    .WithOne(m => m.Manufacturer)
            //    .HasForeignKey(m => m.ManufacturerCode);

            builder.HasData(
                new Manufacturer
                {
                    ManufacturerCode = Guid.Parse("d56a518d-346d-4a5c-bb2e-b0da1e634e40"),
                    ManufacturerName = "Toyota",
                    OtherManufacturerDetails = "A well-known Japanese car manufacturer"
                }
            );
        }
    }
}
