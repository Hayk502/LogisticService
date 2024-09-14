using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Models
{
    public class Route
    {
        public int Id { get; set; } 
        public string StartLocation { get; set; } 
        public string EndLocation { get; set; } 

        
        public Route(string startLocation, string endLocation)
        {
            StartLocation = startLocation ?? throw new ArgumentNullException(nameof(startLocation));
            EndLocation = endLocation ?? throw new ArgumentNullException(nameof(endLocation));
        }
    }
}
