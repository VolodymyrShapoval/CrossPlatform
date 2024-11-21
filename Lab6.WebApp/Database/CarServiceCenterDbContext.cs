using Lab6.WebApp.Database.Configurations;
using Lab6.WebApp.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab6.WebApp.Database
{
    public class CarServiceCenterDbContext(DbContextOptions<CarServiceCenterDbContext>) 
        : DbContext
    {

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<ServiceBooking> ServiceBookings { get; set; }
        public DbSet<MechanicOnService> MechanicsOnServices { get; set; }

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbProvider = "SqlLite";

            switch (dbProvider)
            {
                case "MSSQL":
                    optionsBuilder.UseSqlServer("Server=localhost;Database=CarServiceDB;Trusted_Connection=True;");
                    break;
                case "Postgres":
                    optionsBuilder.UseNpgsql("Host=localhost;Database=CarServiceDB;Username=postgres;Password=postgres;");
                    break;
                case "SqlLite":
                    optionsBuilder.UseSqlite("Data Source=CarServiceDB.db");
                    break;
                case "InMemory":
                    optionsBuilder.UseInMemoryDatabase("InMemoryDb");
                    break;
                default:
                    throw new System.Exception("Unsupported database provider");
            }
        }
    }
}
