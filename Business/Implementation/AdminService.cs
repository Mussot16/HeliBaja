using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System.Collections.Generic;

namespace Business.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IUserRepository _userRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IAgendaRepository _agendaRepository;

        public AdminService(IAdminRepository adminRepository, IBookingRepository bookingRepository, IFlightRepository flightRepository,
                            IUserRepository userRepository, IInventoryRepository inventoryRepository, IAgendaRepository agendaRepository)
        {
            _adminRepository = adminRepository;
            _bookingRepository = bookingRepository;
            _flightRepository = flightRepository;
            _userRepository = userRepository;
            _inventoryRepository = inventoryRepository;
            _agendaRepository = agendaRepository;
        }

        // Admin

        public List<Admin> GetAdmins()
        {
            return _adminRepository.GetAdmins();
        }

        public Admin GetAdminById(int adminId)
        {
            return _adminRepository.GetAdminById(adminId);
        }

        public bool AddAdmin(Admin admin)
        {
            return _adminRepository.AddAdmin(admin);
        }

        public bool UpdateAdmin(Admin admin)
        {
            return _adminRepository.UpdateAdmin(admin);
        }

        public bool DeleteAdmin(int adminId)
        {
            return _adminRepository.DeleteAdmin(adminId);
        }

        // Booking

        public List<Booking> GetAdminBookings()
        {
            return _bookingRepository.GetAdminBookings();
        }

        public bool AddAdminBooking(Booking booking)
        {
            return _bookingRepository.AddAdminBooking(booking);
        }

        public bool UpdateAdminBooking(Booking booking)
        {
            return _bookingRepository.UpdateAdminBooking(booking);
        }

        public bool DeleteAdminBooking(int bookingId)
        {
            return _bookingRepository.DeleteAdminBooking(bookingId);
        }

        // Flight

        public List<Flight> GetAdminFlights()
        {
            return _flightRepository.GetAdminFlights();
        }

        public bool AddAdminFlight(Flight flight)
        {
            return _flightRepository.AddAdminFlight(flight);
        }

        public bool UpdateAdminFlight(Flight flight)
        {
            return _flightRepository.UpdateAdminFlight(flight);
        }

        public bool DeleteAdminFlight(int flightId)
        {
            return _flightRepository.DeleteAdminFlight(flightId);
        }

        // User

        public List<Users> GetAdminUsers()
        {
            return _userRepository.GetAdminUsers();
        }

        public Users GetAdminUserById(int userId)
        {
            return NewMethod(userId);
        }

        private Users NewMethod(int userId)
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

        // Inventory

        public List<Inventory> GetAdminInventory()
        {
            return _inventoryRepository.GetAdminInventory();
        }

        public Inventory GetAdminInventoryById(int itemId)
        {
            return _inventoryRepository.GetAdminInventoryById(itemId);
        }

        public bool AddAdminInventory(Inventory item)
        {
            return _inventoryRepository.AddAdminInventory(item);
        }

        public bool UpdateAdminInventory(Inventory item)
        {
            return _inventoryRepository.UpdateAdminInventory(item);
        }

        public bool DeleteAdminInventory(int itemId)
        {
            return _inventoryRepository.DeleteAdminInventory(itemId);
        }

        // Agenda

        public List<Agenda> GetAdminAgenda()
        {
            return _agendaRepository.GetAdminAgenda();
        }

        public Agenda GetAdminAgendaById(int entryId)
        {
            return _agendaRepository.GetAdminAgendaById(entryId);
        }

        public bool AddAdminAgenda(Agenda entry)
        {
            return _agendaRepository.AddAdminAgenda(entry);
        }

        public bool UpdateAdminAgenda(Agenda entry)
        {
            return _agendaRepository.UpdateAdminAgenda(entry);
        }

        public bool DeleteAdminAgenda(int entryId)
        {
            return _agendaRepository.DeleteAdminAgenda(entryId);
        }
    }
}
