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

            modelBuilder.Entity<OperationalStatus>()
                .Property(o => o.Coefficient)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Container>()
                .Property(c => c.Coefficient)
                .HasColumnType("decimal(18,2)");
        }
    }
}
