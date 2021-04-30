using fiap.aws.serveless.trip.kernell.DomainModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fiap.aws.serveless.trip.repository
{
    public interface ITripRepository
    {
        public Task<IEnumerable<TripDomain>> GetAll();

        public Task<IEnumerable<TripDomain>> GetByCity(string city);

        public Task<TripDomain> Add(TripDomain trip);

    }
}