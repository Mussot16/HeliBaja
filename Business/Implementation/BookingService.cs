using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Implementation
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            return await Task.Run(() => _bookingRepository.GetAll());
        }

        public async Task<Booking> GetBookingById(int bookingId)
        {
            return await Task.Run(() => _bookingRepository.Get(bookingId));
        }

        public async Task<int> AddBooking(Booking booking)
        {
            return await Task.Run(() => _bookingRepository.Add(booking));
        }

        public async Task<bool> UpdateBooking(Booking booking)
        {
            return await Task.Run(() => _bookingRepository.Update(booking));
        }

        public async Task<bool> DeleteBooking(int bookingId)
        {
            return await Task.Run(() => _bookingRepository.Delete(bookingId));
        }

        public List<Booking> GetBookingsByClient(int clientId)
        {
            return _bookingRepository.GetBookingsByClient(clientId);
        }

        public List<Booking> GetBookingsByFlight(int flightId)
        {
            return _bookingRepository.GetBookingsByFlight(flightId);
        }
    }
}