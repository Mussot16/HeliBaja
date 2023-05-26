using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System.Collections.Generic;

namespace Business.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int AddUser(Users user)
        {
            return _userRepository.AddUser(user);
        }

        public bool UpdateUser(Users user)
        {
            return _userRepository.UpdateUser(user);
        }

        public bool DeleteUser(int userId)
        {
            return _userRepository.DeleteUser(userId);
        }

        public Users GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public Users GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public List<Users> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public List<Booking> GetUserBookings(int userId)
        {
            return _userRepository.GetUserBookings(userId);
        }

        public List<Flight> GetAvailableFlights()
        {
            return _userRepository.GetAvailableFlights();
        }

        public bool BookFlight(int userId, int flightId)
        {
            return _userRepository.BookFlight(userId, flightId);
        }

        public bool CancelBooking(int bookingId)
        {
            return _userRepository.CancelBooking(bookingId);
        }

        public List<Users> GetAdminUsers()
        {
            return _userRepository.GetAdminUsers();
        }

        public Users GetAdminUserById(int userId)
        {
            return _userRepository.GetAdminUserById(userId);
        }

        public bool AddAdminUser(Users user)
        {
            return _userRepository.AddAdminUser(user);
        }

        public bool UpdateAdminUser(Users user)
        {
            return _userRepository.UpdateAdminUser(user);
        }

        public bool DeleteAdminUser(int userId)
        {
            return _userRepository.DeleteAdminUser(userId);
        }
    }
}