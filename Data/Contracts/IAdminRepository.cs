using System.Collections.Generic;
using Domain.Model;

namespace Data.Contracts
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        // Admin
        List<Admin> GetAdmins();
        Admin GetAdminById(int adminId);
        bool AddAdmin(Admin admin);
        bool UpdateAdmin(Admin admin);
        bool DeleteAdmin(int adminId);

        // Booking
        List<Booking> GetAdminBookings();
        bool AddAdminBooking(Booking booking);
        bool UpdateAdminBooking(Booking booking);
        bool DeleteAdminBooking(int bookingId);

        // Flight
        List<Flight> GetAdminFlights();
        bool AddAdminFlight(Flight flight);
        bool UpdateAdminFlight(Flight flight);
        bool DeleteAdminFlight(int flightId);

        // User
        List<Users> GetAdminUsers();
        Users GetAdminUserById(int userId);
        bool AddAdminUser(Users user);
        bool UpdateAdminUser(Users user);
        bool DeleteAdminUser(int userId);

        // Inventory
        List<Inventory> GetAdminInventory();
        Inventory GetAdminInventoryById(int itemId);
        bool AddAdminInventory(Inventory item);
        bool UpdateAdminInventory(Inventory item);
        bool DeleteAdminInventory(int itemId);

        // Agenda
        List<Agenda> GetAdminAgenda();
        Agenda GetAdminAgendaById(int entryId);
        bool AddAdminAgenda(Agenda entry);
        bool UpdateAdminAgenda(Agenda entry);
        bool DeleteAdminAgenda(int entryId);
    }
}
