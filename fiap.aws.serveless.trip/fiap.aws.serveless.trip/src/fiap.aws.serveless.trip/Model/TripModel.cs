using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fiap.aws.serveless.trip.Model
{
    public class TripModel
    {
        public string Country { get; set; }

        public string City { get; set;  }
        
        public DateTime Date { get; set; }

        public string Reason { get; set; }

    }
}
