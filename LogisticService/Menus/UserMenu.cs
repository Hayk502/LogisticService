using LogisticService.Calculations;
using LogisticService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Menus
{
    internal class UserMenu
    {
        private readonly DataContext _context;
        private readonly PricingService _pricingService;

        public UserMenu(DataContext context, PricingService pricingService)
        {
            _context = context;
            _pricingService = pricingService;
        }

        public void DisplayMenu(User user)
        {
            Console.WriteLine($"Welcome, {user.Name}!");
            Console.WriteLine("1. View Available Routes");
            Console.WriteLine("2. Request Price");
            Console.WriteLine("0. Exit");
            HandleMenuInput(user);
        }

        private void HandleMenuInput(User user)
        {
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    user.ViewAvailableRoutes(_context);
                    break;
                case "2":
                    RequestPrice(user);
                    break;
                case "0":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }

        private void RequestPrice(User user)
        {
            Console.WriteLine("Enter Start Location:");
            var startLocation = Console.ReadLine();
            Console.WriteLine("Enter End Location:");
            var endLocation = Console.ReadLine();

            var route = _context.Routes.FirstOrDefault(r => r.StartLocation == startLocation && r.EndLocation == endLocation);
            if (route == null)
            {
                Console.WriteLine("Route not found.");
                return;
            }

            var vehicleType = _context.VehicleTypes.First();
            var operationalStatus = _context.Status.First(); 
            var container = _context.Containers.First();

            var price = user.RequestPrice(_pricingService, route, vehicleType, operationalStatus, container);
            Console.WriteLine($"Calculated Price: {price}");
        }
    }
}
