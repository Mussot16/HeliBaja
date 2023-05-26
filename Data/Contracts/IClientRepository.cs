using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IClientRepository : IGenericRepository<Clients>
    {
        Task<IEnumerable<Clients>> GetAll();
        new Task<Clients> Get(int id);
        new Task<int> Add(Clients entity);
        new Task<bool> Update(Clients entity);
        new Task<bool> Delete(int id);
        List<Booking> GetBookings(int clientId);
        bool AddBookingToClient(int bookingId, int clientId);
        bool RemoveBookingFromClient(int bookingId, int clientId);
    }
}