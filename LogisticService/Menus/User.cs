using LogisticService.Calculations;
using LogisticService.Data;
using LogisticService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Menus
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public User(int id, string name)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void ViewAvailableRoutes(DataContext context)
        {
            var routes = context.Routes.ToList();
            Console.WriteLine("Available Routes:");
            foreach (var route in routes)
            {
                Console.WriteLine($"{route.StartLocation} -> {route.EndLocation} | Fixed Price: {route.FixedPrice?.ToString() ?? "Distance-based pricing"}");
            }
        }

        public decimal RequestPrice(PricingService pricingService, Route route, VehicleType vehicleType, OperationalStatus operationalStatus, Container container)
        {
            return pricingService.CalculatePrice(route, vehicleType, operationalStatus, container);
        }
    }
}
