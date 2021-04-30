using fiap.aws.serveless.trip.kernell.DomainModel;
using fiap.aws.serveless.trip.kernell.ServiceModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fiap.aws.serveless.trip.services
{
    public interface ITripService
    {
        public Task<IEnumerable<TripResponse>> GetAll(string country);

        public Task<IEnumerable<TripResponse>> GetByCity(string country, string city);

        public Task<TripResponse> Add(AddTripRequest trip);
    }
}