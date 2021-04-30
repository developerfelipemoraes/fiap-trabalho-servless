using fiap.aws.serveless.trip.kernell.DomainModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fiap.aws.serveless.trip.repository
{
    public class TripRepository : ITripRepository
    {
        public Task<TripDomain> Add(TripDomain trip)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TripDomain>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TripDomain>> GetByCity(string city)
        {
            throw new NotImplementedException();
        }
    }
}
