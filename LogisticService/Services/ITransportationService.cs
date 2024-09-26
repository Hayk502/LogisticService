using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Services
{
    internal interface ITransportationService
    {
        Task<decimal> GetTransportationPrice(int routeId, int vehicleId, int statusId, int containerId);
    }
}
