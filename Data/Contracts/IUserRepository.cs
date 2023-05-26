using System.Collections.Generic;
using Domain.Model;

namespace Data.Contracts
{
    public interface IUserRepository
    {
        int AddUser(Users user);
        bool UpdateUser(Users user);
        bool DeleteUser(int userId);
        Users GetUserById(int userId);
        Users GetUserByEmail(string email);
        List<Users> GetAllUsers();
        List<Booking> GetUserBookings(int userId);
        List<Flight> GetAvailableFlights();
        bool BookFlight(int userId, int flightId);
        bool CancelBooking(int bookingId);
        List<Users> GetAdminUsers();
        Users GetAdminUserById(int userId);
        bool AddAdminUser(Users user);
        bool UpdateAdminUser(Users user);
        bool DeleteAdminUser(int userId);
    }
}