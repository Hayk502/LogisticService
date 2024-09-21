using LogisticService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Menus
{
    internal class AdminPanel
    {
        private readonly DataContext _context;

        public AdminPanel(DataContext context)
        {
            _context = context;
        }

        public async Task ManageRoutes()
        {
            Console.WriteLine("Managing Routes...");
            var routes = _context.Routes.ToList();
            foreach (var route in routes)
            {
                Console.WriteLine($"Route: {route.StartLocation} -> {route.EndLocation} | Fixed Price: {route.FixedPrice}");
            }
        }

        public async Task ManageVehicleTypes()
        {
            Console.WriteLine("Managing Vehicle Types...");
            var vehicleTypes = _context.VehicleTypes.ToList();
            foreach (var vehicleType in vehicleTypes)
            {
                Console.WriteLine($"Vehicle Type: {vehicleType.Name} | Coefficient: {vehicleType.Coefficient}");
            }
        }

        public async Task ManageOperationalStatuses()
        {
            Console.WriteLine("Managing Operational Statuses...");
            var statuses = _context.Status.ToList();
            foreach (var status in statuses)
            {
                Console.WriteLine($"Operational Status: {(status.IsOperational ? "Operational" : "Not Operational")}");
            }
        }
    }
}
