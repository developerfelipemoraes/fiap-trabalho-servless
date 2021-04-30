using AutoMapper;
using fiap.aws.serveless.trip.kernell.DomainModel;
using fiap.aws.serveless.trip.kernell.ServiceModel;
using fiap.aws.serveless.trip.repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fiap.aws.serveless.trip.services
{
    public class TripService : ITripService
    {
        private readonly  ITripRepository tripRepository;
        private readonly IMapper mapper;

        public TripService ( ITripRepository tripRepository_, IMapper mapper_)
        {
            tripRepository = tripRepository_;
            mapper = mapper_;
        }

        public async Task<TripResponse> Add(AddTripRequest tripRequest)
        {
            var tripDomain = mapper.Map<TripDomain>(tripRequest);
            var trip = await tripRepository.Add(tripDomain);
            var tripResponse = mapper.Map<TripResponse>(trip);
            return tripResponse;
        }

        public async Task<IEnumerable<TripResponse>> GetAll()
        {
            var tripDomain = await tripRepository.GetAll();
            var tripResponse = mapper.Map<TripResponse>(tripDomain);
            return (IEnumerable<TripResponse>)tripResponse;
        }

        public async Task<IEnumerable<TripResponse>> GetByCity(string city)
        {
            var tripDomain = await tripRepository.GetByCity(city);
            var tripResponse = mapper.Map<TripResponse>(tripDomain);
            return (IEnumerable<TripResponse>)tripResponse;
        }
    }
}
