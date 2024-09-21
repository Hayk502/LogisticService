using LogisticService.Data;
using LogisticService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Calculations
{
    public class PricingService
    {
        private readonly DataContext _context;

        public PricingService(DataContext context)
        {
            _context = context;
        }

        public decimal CalculatePrice(Route route, VehicleType vehicleType, OperationalStatus operationalStatus, Container container)
        {
            if (route == null) throw new ArgumentNullException(nameof(route));
            if (vehicleType == null) throw new ArgumentNullException(nameof(vehicleType));
            if (operationalStatus == null) throw new ArgumentNullException(nameof(operationalStatus));
            if (container == null) throw new ArgumentNullException(nameof(container));

            if (route.FixedPrice.HasValue)
            {
                return route.FixedPrice.Value;
            }


            var basePrice = CalculateBasePrice(route);
            var containerCost = container.IsClosed ? 50 : 0;
            var vehicleCoefficient = vehicleType.Coefficient;
            var operationalCost = operationalStatus.IsOperational ? 0 : 100;

            return basePrice * vehicleCoefficient + containerCost + operationalCost;
        }

        private decimal CalculateBasePrice(Route route)
        {

            var distance = GetDistance(route.StartLocation, route.EndLocation);
            var costPerUnitDistance = 10;
            return distance * costPerUnitDistance;
        }

        //private decimal GetVehicleCoefficient(string vehicleTypeName)
        //{

        //    return vehicleTypeName switch
        //    {
        //        "Sedan" => 1.0m,
        //        "SUV" => 1.2m,
        //        "Truck" => 1.5m,
        //        "Van" => 1.3m,
        //        "Pickup" => 1.4m,
        //        _ => 1.0m
        //    };
        //}

        private decimal GetDistance(string startLocation, string endLocation)
        {
            return 100;
        }
    }
}
