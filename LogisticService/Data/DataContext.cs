using LogisticService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Route> Routes { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<OperationalStatus> Status { get; set; }
        public DbSet<Container> Containers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=AutoLogisticsDB;Integrated Security=True;Encrypt=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleType>()
                .Property(v => v.Coefficient)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Route>()
                .Property(r => r.FixedPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<VehicleType>().HasData(
                new VehicleType { Id = 1, Name = "Sedan", Coefficient = 1.0m },
                new VehicleType { Id = 2, Name = "Truck", Coefficient = 1.5m }
            );

            modelBuilder.Entity<Route>().HasData(
                new Route { Id = 1, StartLocation = "Paris", EndLocation = "Berlin", FixedPrice = 500m },
                new Route { Id = 2, StartLocation = "London", EndLocation = "Rome" }
            );

            modelBuilder.Entity<OperationalStatus>().HasData(
                new OperationalStatus { Id = 1, IsOperational = true },
                new OperationalStatus { Id = 2, IsOperational = false }
            );

            modelBuilder.Entity<Container>().HasData(
                new Container { Id = 1, IsClosed = true },
                new Container { Id = 2, IsClosed = false }
            );
        }
    }
}
