using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IClientService
    {
        Task<IEnumerable<Clients>> GetAllClients();
        Task<Clients> GetClientById(int clientId);
        Task<int> AddClient(Clients client);
        Task<bool> UpdateClient(Clients client);
        Task<bool> DeleteClient(int clientId);
        List<Booking> GetBookings(int clientId);
        bool AddBookingToClient(int bookingId, int clientId);
        bool RemoveBookingFromClient(int bookingId, int clientId);
    }
}