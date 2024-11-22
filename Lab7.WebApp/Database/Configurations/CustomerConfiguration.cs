using Lab7.WebApp.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Lab7.WebApp.Database.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerId);

            builder
                .HasMany(c => c.Cars)
                .WithOne(ca => ca.Customer)
                .HasForeignKey(ca => ca.CustomerId);

            builder
                .HasMany(c => c.ServiceBookings)
                .WithOne(sb => sb.Customer)
                .HasForeignKey(sb => sb.CustomerId);

            builder.HasData(
                new Customer
                {
                    CustomerId = Guid.Parse("e3c8be5d-0c60-4650-9b2d-830f1f0b40dc"),
                    FirstName = "John",
                    LastName = "Doe",
                    Title = "Mr.",
                    Gender = "Male",
                    EmailAddress = "john.doe@example.com",
                    PhoneNumber = "123-456-7890",
                    AddressLine_1 = "123 Main St",
                    AddressLine_2 = "Apartment 4B",
                    AddressLine_3 = "",
                    City = "Springfield",
                    State = "IL",
                    OtherCustomerDetails = "Loyal customer"
                }
            );
        }
    }
}
