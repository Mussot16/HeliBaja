using Data.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly HeliBajaDBContext _dbContext;

        public ClientRepository(HeliBajaDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(Clients entity)
        {
            _dbContext.Clients.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id_Client;
        }

        public bool Delete(int id)
        {
            var client = _dbContext.Clients.FirstOrDefault(c => c.Id_Client == id);
            if (client == null)
            {
                return false;
            }
            _dbContext.Clients.Remove(client);
            _dbContext.SaveChanges();
            return true;
        }

        public Clients Get(int id)
        {
            return _dbContext.Clients.FirstOrDefault(c => c.Id_Client == id);
        }

        public IEnumerable<Clients> GetAll()
        {
            return _dbContext.Clients.ToList();
        }

        public bool Update(Clients entity)
        {
            var existingClient = _dbContext.Clients.FirstOrDefault(c => c.Id_Client == entity.Id_Client);
            if (existingClient == null)
            {
                return false;
            }
            existingClient.Name = entity.Name;
            existingClient.APaterno = entity.APaterno;
            existingClient.AMaterno = entity.AMaterno;
            existingClient.Email = entity.Email;
            existingClient.Password = entity.Password;
            _dbContext.SaveChanges();
            return true;
        }

        public List<Booking> GetBookings(int clientId)
        {
            var bookings = _dbContext.Bookings.Where(b => b.Id_Client == clientId).ToList();
            return bookings;
        }

        public async Task<IEnumerable<Clients>> GetAllAsync()
        {
            return await Task.FromResult(GetAll());
        }

        public async Task<Clients> GetAsync(int id)
        {
            return await Task.FromResult(Get(id));
        }

        public async Task<int> AddAsync(Clients entity)
        {
            return await Task.Run(() => Add(entity));
        }

        public async Task<bool> UpdateAsync(Clients entity)
        {
            return await Task.Run(() => Update(entity));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await Task.Run(() => Delete(id));
        }

        public bool AddBookingToClient(int bookingId, int clientId)
        {
            var client = _dbContext.Clients.FirstOrDefault(c => c.Id_Client == clientId);
            var booking = _dbContext.Bookings.FirstOrDefault(b => b.Id_Booking == bookingId);

            if (client == null || booking == null)
            {
                return false;
            }

            client.Bookings.Add(booking);
            _dbContext.SaveChanges();

            return true;
        }

        public bool RemoveBookingFromClient(int bookingId, int clientId)
        {
            var client = _dbContext.Clients.FirstOrDefault(c => c.Id_Client == clientId);
            var booking = _dbContext.Bookings.FirstOrDefault(b => b.Id_Booking == bookingId);

            if (client == null || booking == null)
            {
                return false;
            }

            client.Bookings.Remove(booking);
            _dbContext.SaveChanges();

            return true;
        }

        Task<IEnumerable<Clients>> IClientRepository.GetAll()
        {
            return GetAllAsync();
        }

        Task<Clients> IClientRepository.Get(int id)
        {
            return GetAsync(id);
        }

        Task<int> IClientRepository.Add(Clients entity)
        {
            return AddAsync(entity);
        }

        Task<bool> IClientRepository.Update(Clients entity)
        {
            return UpdateAsync(entity);
        }

        Task<bool> IClientRepository.Delete(int id)
        {
            return DeleteAsync(id);
        }
    }
}