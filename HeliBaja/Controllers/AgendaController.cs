using Business.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace HeliBaja.Controllers
{
    public class AgendaController : ApiController
    {
        private readonly IAgendaService _agendaService;

        public AgendaController(IAgendaService agendaService)
        {
            _agendaService = agendaService;
        }

        [HttpPost]
        public IHttpActionResult CreateAgenda(Agenda agenda)
        {
            var agendaId = _agendaService.CreateAgenda(agenda);
            return Ok(agendaId);
        }

        [HttpPut]
        public IHttpActionResult UpdateAgenda(int agendaId, Agenda agenda)
        {
            if (agendaId != agenda.Id_Agenda)
            {
                return BadRequest("Invalid agenda ID");
            }

            var result = _agendaService.UpdateAgenda(agenda);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAgenda(int agendaId)
        {
            var result = _agendaService.DeleteAgenda(agendaId);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpGet]
        public IHttpActionResult GetAgendaById(int agendaId)
        {
            var agenda = _agendaService.GetAgendaById(agendaId);
            if (agenda == null)
            {
                return NotFound();
            }
            return Ok(agenda);
        }

        [HttpPost]
        public IHttpActionResult AddFlightToAgenda(int agendaId, int flightId)
        {
            var result = _agendaService.AddFlightToAgenda(agendaId, flightId);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpDelete]
        public IHttpActionResult RemoveFlightFromAgenda(int agendaId, int flightId)
        {
            var result = _agendaService.RemoveFlightFromAgenda(agendaId, flightId);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpGet]
        public IHttpActionResult GetAllAgendas()
        {
            var agendas = _agendaService.GetAllAgendas();
            return Ok(agendas);
        }
    }
}