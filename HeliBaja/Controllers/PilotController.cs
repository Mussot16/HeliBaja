using Business.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace HeliBaja.Controllers
{
    public class PilotController : ApiController
    {
        private readonly IPilotService _pilotService;

        public PilotController(IPilotService pilotService)
        {
            _pilotService = pilotService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllPilots()
        {
            var pilots = await _pilotService.GetAllPilots();
            return Ok(pilots);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetPilotById(int pilotId)
        {
            var pilot = await _pilotService.GetPilotById(pilotId);
            if (pilot == null)
            {
                return NotFound();
            }
            return Ok(pilot);
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddPilot(Pilots pilot)
        {
            var pilotId = await _pilotService.AddPilot(pilot);
            return Ok(pilotId);
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdatePilot(int pilotId, Pilots pilot)
        {
            if (pilotId != pilot.Id_Pilot)
            {
                return BadRequest("Invalid pilot ID");
            }

            var result = await _pilotService.UpdatePilot(pilot);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeletePilot(int pilotId)
        {
            var result = await _pilotService.DeletePilot(pilotId);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpGet]
        public IHttpActionResult GetFlights(int pilotId)
        {
            var flights = _pilotService.GetFlights(pilotId);
            return Ok(flights);
        }

        [HttpPost]
        public IHttpActionResult AddFlightToPilot(int flightId, int pilotId)
        {
            var result = _pilotService.AddFlightToPilot(flightId, pilotId);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpDelete]
        public IHttpActionResult RemoveFlightFromPilot(int flightId, int pilotId)
        {
            var result = _pilotService.RemoveFlightFromPilot(flightId, pilotId);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}