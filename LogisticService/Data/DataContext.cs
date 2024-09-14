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
    }
}
