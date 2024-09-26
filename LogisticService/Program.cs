using LogisticService.Data;
using Microsoft.EntityFrameworkCore;
using System;
using LogisticService.Models;
using LogisticService.Calculations;
using LogisticService.Repository;
using LogisticService.Services;


//using (var context = new DataContext())
//{
//    Console.WriteLine("Enter vehicle type name (e.g., Sedan, Truck):");
//    string vehicleTypeName = Console.ReadLine();

//    Console.WriteLine("Enter vehicle coefficient:");
//    decimal vehicleCoefficient = decimal.Parse(Console.ReadLine());

//    var vehicleType = new VehicleType { Name = vehicleTypeName, Coefficient = vehicleCoefficient };
//    context.VehicleTypes.Add(vehicleType);
//    await context.SaveChangesAsync();

//    Console.WriteLine("Enter route start location:");
//    string startLocation = Console.ReadLine();

//    Console.WriteLine("Enter route end location:");
//    string endLocation = Console.ReadLine();

//    Console.WriteLine("Enter fixed price for route");
//    string fixedPriceInput = Console.ReadLine();
//    decimal? fixedPrice = string.IsNullOrEmpty(fixedPriceInput) ? (decimal?)null : decimal.Parse(fixedPriceInput);

//    decimal basePrice;
//    if (!fixedPrice.HasValue)
//    {
//        Console.WriteLine($"There's no fixed price. Provide a base price for the route from {startLocation} to {endLocation}:");
//        basePrice = decimal.Parse(Console.ReadLine());
//    }
//    else
//    {
//        basePrice = fixedPrice.Value;
//    }
//    var route = new Route { StartLocation = startLocation, EndLocation = endLocation, FixedPrice = fixedPrice };
//    context.Routes.Add(route);
//    await context.SaveChangesAsync();

//    Console.WriteLine("Is the vehicle operational? (yes/no):");
//    bool isOperational = Console.ReadLine().ToLower() == "yes";

//    Console.WriteLine("Enter operational status coefficient:");
//    decimal operationalCoefficient = decimal.Parse(Console.ReadLine());

//    var operationalStatus = new OperationalStatus { IsOperational = isOperational, Coefficient = operationalCoefficient };
//    context.Status.Add(operationalStatus);
//    await context.SaveChangesAsync();

//    Console.WriteLine("Is the container closed? (yes/no):");
//    bool isClosed = Console.ReadLine().ToLower() == "yes";

//    Console.WriteLine("Enter container coefficient:");
//    decimal containerCoefficient = decimal.Parse(Console.ReadLine());

//    var container = new Container { IsClosed = isClosed, Coefficient = containerCoefficient };
//    context.Containers.Add(container);
//    await context.SaveChangesAsync();

//    decimal finalPrice = basePrice * vehicleCoefficient * operationalCoefficient * containerCoefficient;

//    Console.WriteLine($"Calculated transportation price: {finalPrice:F2}");
//}

using (var context = new DataContext())
{
    var routeRepository = new Repository<Route, int, DataContext>(context);
    var vehicleRepository = new Repository<VehicleType, int, DataContext>(context);
    var statusRepository = new Repository<OperationalStatus, int, DataContext>(context);
    var containerRepository = new Repository<Container, int, DataContext>(context);
    var pricingService = new PricingService(context);
    var transportationService = new TransportationService(
        routeRepository, vehicleRepository, statusRepository, containerRepository, pricingService);

    Console.WriteLine("Enter vehicle type (e.g., Sedan, Truck):");
    string vehicleTypeName = Console.ReadLine();
    var vehicleType = await context.VehicleTypes.FirstOrDefaultAsync(v => v.Name == vehicleTypeName);

    if (vehicleType == null)
    {
        Console.WriteLine("Invalid vehicle type.");
        return;
    }

    Console.WriteLine("Enter route start location:");
    string startLocation = Console.ReadLine();

    Console.WriteLine("Enter route end location:");
    string endLocation = Console.ReadLine();

    var route = await context.Routes.FirstOrDefaultAsync(r => r.StartLocation == startLocation && r.EndLocation == endLocation);

    if (route == null)
    {
        Console.WriteLine("Invalid route.");
        return;
    }

    Console.WriteLine("Is the vehicle operational? (yes/no):");
    bool isOperational = Console.ReadLine().ToLower() == "yes";
    var operationalStatus = await context.Status.FirstOrDefaultAsync(s => s.IsOperational == isOperational);

    if (operationalStatus == null)
    {
        Console.WriteLine("Invalid operational status.");
        return;
    }

    Console.WriteLine("Is the container closed? (yes/no):");
    bool isClosed = Console.ReadLine().ToLower() == "yes";
    var container = await context.Containers.FirstOrDefaultAsync(c => c.IsClosed == isClosed);

    if (container == null)
    {
        Console.WriteLine("Invalid container status.");
        return;
    }

    var finalPrice = await transportationService.GetTransportationPrice(route.Id, vehicleType.Id, operationalStatus.Id, container.Id);

    Console.WriteLine($"Calculated transportation price: {finalPrice:F2}");
}