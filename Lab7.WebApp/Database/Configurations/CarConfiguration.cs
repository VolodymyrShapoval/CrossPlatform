using Lab7.WebApp.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Lab7.WebApp.Database.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.LicenceNumber);

            builder
                .HasOne(c => c.Model)
                .WithMany(m => m.Cars)
                .HasForeignKey(c => c.ModelCode);

            builder
                .HasOne(c => c.Customer)
                .WithMany(cu => cu.Cars)
                .HasForeignKey(c => c.CustomerId);

            builder
                .HasMany(c => c.ServiceBookings)
                .WithOne(sb => sb.Car)
                .HasForeignKey(sb => sb.LicenceNumber);

            builder.HasData(
                new Car
                {
                    LicenceNumber = Guid.Parse("4ef5c97f-2e2d-4a51-a614-04be77b5c65e"),
                    ModelCode = Guid.Parse("f6b97f25-49ef-42c4-a2c6-7e4a5581e7a9"),
                    CustomerId = Guid.Parse("e3c8be5d-0c60-4650-9b2d-830f1f0b40dc"),
                    CurrentMileage = 50000,
                    EngineSize = 1.8,
                    OtherCarDetails = "Well-maintained"
                }
            );
        }
    }
}
