using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Models
{
    public class OperationalStatus
    {
        public int Id { get; set; }
        public bool IsOperational { get; set; }

        public OperationalStatus(bool isOperational)
        {
            IsOperational = isOperational;
        }
        public OperationalStatus() { }
    }
}
