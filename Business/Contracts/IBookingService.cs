using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Contracts;

namespace Business.Contracts
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllBookings();
        Task<Booking> GetBookingById(int bookingId);
        Task<int> AddBooking(Booking booking);
        Task<bool> UpdateBooking(Booking booking);
        Task<bool> DeleteBooking(int bookingId);
        List<Booking> GetBookingsByClient(int clientId);
        List<Booking> GetBookingsByFlight(int flightId);
    }
}