using Business.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace HeliBaja.Controllers
{
    public class FlightController : ApiController
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        public IHttpActionResult GetFlights()
        {
            var flights = _flightService.GetFlights();
            return Ok(flights);
        }

        [HttpGet]
        public IHttpActionResult GetAdminFlights()
        {
            var flights = _flightService.GetAdminFlights();
            return Ok(flights);
        }

        [HttpGet]
        public IHttpActionResult GetFlightById(int flightId)
        {
            var flight = _flightService.GetFlightById(flightId);
            if (flight == null)
            {
                return NotFound();
            }
            return Ok(flight);
        }

        [HttpPost]
        public IHttpActionResult AddFlight(Flight flight)
        {
            var result = _flightService.AddFlight(flight);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpPut]
        public IHttpActionResult UpdateFlight(int flightId, Flight flight)
        {
            if (flightId != flight.Id_Flight)
            {
                return BadRequest("Invalid flight ID");
            }

            var result = _flightService.UpdateFlight(flight);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpDelete]
        public IHttpActionResult DeleteFlight(int flightId)
        {
            var result = _flightService.DeleteFlight(flightId);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpPost]
        public IHttpActionResult AssignPilotToFlight(int flightId, int pilotId)
        {
            var result = _flightService.AssignPilotToFlight(flightId, pilotId);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpDelete]
        public IHttpActionResult RemovePilotFromFlight(int flightId)
        {
            var result = _flightService.RemovePilotFromFlight(flightId);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}