using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Coefficient { get; set; }

        public VehicleType(string name, decimal coefficient)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Coefficient = coefficient;
        }

        public VehicleType() { }
    }
}
