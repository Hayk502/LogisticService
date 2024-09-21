using LogisticService.Data;
using LogisticService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LogisticService.Repository.IRepository;

namespace LogisticService.Calculations
{
    public class TransportationService
    {
        private readonly IRepository<Route, int, DataContext> _routeRepository;
        private readonly IRepository<VehicleType, int, DataContext> _vehicleRepository;
        private readonly IRepository<OperationalStatus, int, DataContext> _statusRepository;
        private readonly IRepository<Container, int, DataContext> _containerRepository;
        private readonly PricingService _pricingService;

        public TransportationService(
            IRepository<Route, int, DataContext> routeRepository,
            IRepository<VehicleType, int, DataContext> vehicleRepository,
            IRepository<OperationalStatus, int, DataContext> statusRepository,
            IRepository<Container, int, DataContext> containerRepository,
            PricingService pricingService)
        {
            _routeRepository = routeRepository;
            _vehicleRepository = vehicleRepository;
            _statusRepository = statusRepository;
            _containerRepository = containerRepository;
            _pricingService = pricingService;
        }

        public async Task<decimal> GetTransportationPrice(int routeId, int vehicleId, int statusId, int containerId)
        {
            var route = await _routeRepository.GetByIdAsync(routeId);
            var vehicle = await _vehicleRepository.GetByIdAsync(vehicleId);
            var status = await _statusRepository.GetByIdAsync(statusId);
            var container = await _containerRepository.GetByIdAsync(containerId);

            return _pricingService.CalculatePrice(route, vehicle, status, container);
        }
    }
}
