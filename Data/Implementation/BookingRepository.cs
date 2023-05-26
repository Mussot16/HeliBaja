using Data.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HeliBajaDBContext _dbContext;

        public BookingRepository(HeliBajaDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(Booking entity)
        {
            _dbContext.Bookings.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id_Booking;
        }

        public bool Delete(int id)
        {
            var booking = _dbContext.Bookings.Find(id);
            if (booking != null)
            {
                _dbContext.Bookings.Remove(booking);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Booking Get(int id)
        {
            return _dbContext.Bookings.FirstOrDefault(b => b.Id_Booking == id);
        }

        public bool Update(Booking entity)
        {
            if (!_dbContext.Bookings.Local.Any(b => b.Id_Booking == entity.Id_Booking))
            {
                _dbContext.Bookings.Attach(entity);
            }
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }

        public bool AddAdminBooking(Booking booking)
        {
            _dbContext.Bookings.Add(booking);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteAdminBooking(int bookingId)
        {
            var booking = _dbContext.Bookings.Find(bookingId);
            if (booking == null)
            {
                return false;
            }

            _dbContext.Bookings.Remove(booking);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Booking> GetAdminBookings()
        {
            return _dbContext.Bookings.ToList();
        }

        public List<Booking> GetBookingsByClient(int clientId)
        {
            return _dbContext.Bookings.Where(b => b.Id_Client == clientId).ToList();
        }

        public List<Booking> GetBookingsByFlight(int flightId)
        {
            return _dbContext.Bookings.Where(b => b.Id_Flight == flightId).ToList();
        }

        public bool UpdateAdminBooking(Booking booking)
        {
            if (!_dbContext.Bookings.Local.Any(b => b.Id_Booking == booking.Id_Booking))
            {
                _dbContext.Bookings.Attach(booking);
            }

            _dbContext.Entry(booking).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<Booking> GetAll()
        {
            return _dbContext.Bookings.ToList();
        }
    }
}