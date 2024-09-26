using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Models
{
    public class Container
    {
        public Container(bool isClosed)
        {
            IsClosed = isClosed;
        }

        public int Id { get; set; }
        public bool IsClosed { get; set; }
        public decimal Coefficient { get; set; }

        public Container() { }
    }
}
