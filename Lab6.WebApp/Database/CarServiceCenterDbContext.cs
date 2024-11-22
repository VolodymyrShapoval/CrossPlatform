using Lab6.WebApp.Database.Configurations;
using Lab6.WebApp.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Lab6.WebApp.Database
{
    public class CarServiceCenterDbContext : DbContext
    {
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<ServiceBooking> ServiceBookings { get; set; }
        public DbSet<MechanicOnService> MechanicsOnServices { get; set; }

        public CarServiceCenterDbContext(DbContextOptions<CarServiceCenterDbContext> options)
           : base(options) 
        { 
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ManufacturerConfiguration());
            modelBuilder.ApplyConfiguration(new ModelConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new MechanicConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceBookingConfiguration());
            modelBuilder.ApplyConfiguration(new MechanicOnServiceConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
