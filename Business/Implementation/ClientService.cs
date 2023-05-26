using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<Clients>> GetAllClients()
        {
            return await _clientRepository.GetAll();
        }

        public async Task<Clients> GetClientById(int clientId)
        {
            return await _clientRepository.Get(clientId);
        }

        public async Task<int> AddClient(Clients client)
        {
            return await _clientRepository.Add(client);
        }

        public async Task<bool> UpdateClient(Clients client)
        {
            return await _clientRepository.Update(client);
        }

        public async Task<bool> DeleteClient(int clientId)
        {
            return await _clientRepository.Delete(clientId);
        }

        public List<Booking> GetBookings(int clientId)
        {
            return _clientRepository.GetBookings(clientId);
        }

        public bool AddBookingToClient(int bookingId, int clientId)
        {
            return _clientRepository.AddBookingToClient(bookingId, clientId);
        }

        public bool RemoveBookingFromClient(int bookingId, int clientId)
        {
            return _clientRepository.RemoveBookingFromClient(bookingId, clientId);
        }
    }
}