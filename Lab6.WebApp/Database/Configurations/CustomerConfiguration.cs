using Lab6.WebApp.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab6.WebApp.Database.Configurations
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
        }
    }
}
