using System;
using System.Collections.Generic;
using System.Text;

namespace fiap.aws.serveless.trip.kernell.DomainModel
{
    public class TripDomain
    {
        public string Country { get; set; }

        public string City { get; set; }

        public DateTime Date { get; set; }

        public string Reason { get; set; }
    }
}
