﻿using Lab6.WebApp.Database.Models;
using Microsoft.EntityFrameworkCore;

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
