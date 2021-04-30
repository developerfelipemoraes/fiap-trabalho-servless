using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using fiap.aws.serveless.trip.kernell.ServiceModel;
using fiap.aws.serveless.trip.Model;
using fiap.aws.serveless.trip.services;
using Microsoft.AspNetCore.Mvc;

namespace fiap.aws.serveless.trip.Controllers
{
    [Route("api/[controller]")]
    public class TripsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITripService _tripService;

        public TripsController(ITripService tripService, IMapper mapper) {
            _tripService = tripService;
            _mapper = mapper;
        }

        // GET api/values
        [HttpGet("{Country}")]
        public async  Task<IActionResult> Get(string country )
        {
            var tripReponse = await _tripService.GetAll(country);
            var tripsModel = _mapper.Map<IList<TripModel>>(tripReponse);
            if (tripsModel.Count > 0)
                return Ok(tripsModel);
            else
                return NotFound();
        }

        [HttpGet("{Country}/{City}")]
        public async Task<IActionResult> GetCityAsync(string country, string city) {

            var tripReponse = await _tripService.GetByCity(country, city);
            var tripsModel = _mapper.Map<IList<TripModel>>(tripReponse);
            if (tripsModel.Count > 0)
                return Ok(tripsModel);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TripModel tripModel)
        {
            var tripRequest = _mapper.Map<AddTripRequest>(tripModel);
            var tripReponse = await _tripService.Add(tripRequest);
            var trip = _mapper.Map<TripModel>(tripReponse);
            if (trip != null)
                return Ok(trip);
            else
                return NotFound();
        }

    }
}
