using Business.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HeliBaja.Controllers
{
    public class ClientController : ApiController
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllClients()
        {
            var clients = await _clientService.GetAllClients();
            return Ok(clients);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetClientById(int clientId)
        {
            var client = await _clientService.GetClientById(clientId);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddClient(Clients client)
        {
            var clientId = await _clientService.AddClient(client);
            return Ok(clientId);
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateClient(int clientId, Clients client)
        {
            if (clientId != client.Id_Client)
            {
                return BadRequest("Invalid client ID");
            }

            var result = await _clientService.UpdateClient(client);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteClient(int clientId)
        {
            var result = await _clientService.DeleteClient(clientId);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpGet]
        public IHttpActionResult GetBookings(int clientId)
        {
            var bookings = _clientService.GetBookings(clientId);
            return Ok(bookings);
        }

        [HttpPost]
        public IHttpActionResult AddBookingToClient(int bookingId, int clientId)
        {
            var result = _clientService.AddBookingToClient(bookingId, clientId);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpDelete]
        public IHttpActionResult RemoveBookingFromClient(int bookingId, int clientId)
        {
            var result = _clientService.RemoveBookingFromClient(bookingId, clientId);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}