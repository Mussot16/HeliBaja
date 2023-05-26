using System.Collections.Generic;
using System.Linq;
using Data.Contracts;
using Domain.Model;

namespace Data.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly List<Admin> _admins;
        private readonly List<Booking> _bookings;
        private readonly List<Flight> _flights;
        private readonly List<Users> _users;
        private readonly List<Inventory> _inventory;
        private readonly List<Agenda> _agenda;

        public AdminRepository()
        {
            // Inicializar datos de ejemplo
            _admins = new List<Admin>();
            _bookings = new List<Booking>();
            _flights = new List<Flight>();
            _users = new List<Users>();
            _inventory = new List<Inventory>();
            _agenda = new List<Agenda>();
        }

        // Implementación de métodos para Admin

        public List<Admin> GetAdmins()
        {
            return _admins;
        }

        public Admin GetAdminById(int adminId)
        {
            return _admins.FirstOrDefault(a => a.Id == adminId);
        }

        public bool AddAdmin(Admin admin)
        {
            var existingAdmin = _admins.FirstOrDefault(a => a.Id == admin.Id);
            if (existingAdmin != null)
            {
                return false; // El admin ya existe, no se puede agregar
            }

            _admins.Add(admin);
            return true;
        }

        public bool UpdateAdmin(Admin admin)
        {
            var existingAdmin = _admins.FirstOrDefault(a => a.Id == admin.Id);
            if (existingAdmin == null)
            {
                return false; // El admin no existe, no se puede actualizar
            }

            existingAdmin.Name = admin.Name;
            existingAdmin.Email = admin.Email;
            // Actualizar otros campos según sea necesario

            return true;
        }

        public bool DeleteAdmin(int adminId)
        {
            var admin = _admins.FirstOrDefault(a => a.Id == adminId);
            if (admin == null)
            {
                return false; // El admin no existe, no se puede eliminar
            }

            _admins.Remove(admin);
            return true;
        }

        // Implementación de métodos para Booking

        public List<Booking> GetAdminBookings()
        {
            return _bookings;
        }

        public bool AddAdminBooking(Booking booking)
        {
            _bookings.Add(booking);
            return true;
        }

        public bool UpdateAdminBooking(Booking booking)
        {
            var existingBooking = _bookings.FirstOrDefault(b => b.Id_Booking == booking.Id_Booking);
            if (existingBooking == null)
            {
                return false; // La reserva no existe, no se puede actualizar
            }

            existingBooking.Id_Client = booking.Id_Client;
            existingBooking.Id_Flight = booking.Id_Flight;
            // Actualizar otros campos según sea necesario

            return true;
        }

        public bool DeleteAdminBooking(int bookingId)
        {
            var booking = _bookings.FirstOrDefault(b => b.Id_Booking == bookingId);
            if (booking == null)
            {
                return false; // La reserva no existe, no se puede eliminar
            }

            _bookings.Remove(booking);
            return true;
        }

        // Implementación de métodos para Flight

        public List<Flight> GetAdminFlights()
        {
            return _flights;
        }

        public bool AddAdminFlight(Flight flight)
        {
            _flights.Add(flight);
            return true;
        }

        public bool UpdateAdminFlight(Flight flight)
        {
            var existingFlight = _flights.FirstOrDefault(f => f.Id_Flight == flight.Id_Flight);
            if (existingFlight != null)
            {
                existingFlight.NumeroVuelo = flight.NumeroVuelo;
                existingFlight.Origen = flight.Origen;
                existingFlight.Destino = flight.Destino;
                existingFlight.HoraSalida = flight.HoraSalida;
                existingFlight.HoraLlegada = flight.HoraLlegada;
                existingFlight.Bookings = flight.Bookings;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteAdminFlight(int flightId)
        {
            var flight = _flights.FirstOrDefault(f => f.Id_Flight == flightId);
            if (flight == null)
            {
                return false; // El vuelo no existe, no se puede eliminar
            }

            _flights.Remove(flight);
            return true;
        }

        // Implementación de métodos para User

        public List<Users> GetAdminUsers()
        {
            return _users;
        }

        public Users GetAdminUserById(int userId)
        {
            return _users.FirstOrDefault(u => u.Id == userId);
        }

        public bool AddAdminUser(Users user)
        {
            _users.Add(user);
            return true;
        }

        public bool UpdateAdminUser(Users user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser == null)
            {
                return false; // El usuario no existe, no se puede actualizar
            }

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            // Actualizar otros campos según sea necesario

            return true;
        }

        public bool DeleteAdminUser(int userId)
        {
            var user = _users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return false; // El usuario no existe, no se puede eliminar
            }

            _users.Remove(user);
            return true;
        }

        // Implementación de métodos para Inventory

        public List<Inventory> GetAdminInventory()
        {
            return _inventory;
        }

        public Inventory GetAdminInventoryById(int itemId)
        {
            return _inventory.FirstOrDefault(i => i.Id_Inventory == itemId);
        }

        public bool AddAdminInventory(Inventory item)
        {
            _inventory.Add(item);
            return true;
        }

        public bool UpdateAdminInventory(Inventory item)
        {
            var existingItem = _inventory.FirstOrDefault(i => i.Id_Inventory == item.Id_Inventory);
            if (existingItem == null)
            {
                return false; // El ítem no existe, no se puede actualizar
            }

            existingItem.Name = item.Name;
            existingItem.Description = item.Description;
            existingItem.Amount = item.Amount;

            return true;
        }

        public bool DeleteAdminInventory(int itemId)
        {
            var item = _inventory.FirstOrDefault(i => i.Id_Inventory == itemId);
            if (item == null)
            {
                return false; // El ítem no existe, no se puede eliminar
            }

            _inventory.Remove(item);
            return true;
        }

        // Implementación de métodos para Agenda

        public List<Agenda> GetAdminAgenda()
        {
            return _agenda;
        }

        public Agenda GetAdminAgendaById(int entryId)
        {
            return _agenda.FirstOrDefault(a => a.Id_Agenda == entryId);
        }

        public bool AddAdminAgenda(Agenda entry)
        {
            _agenda.Add(entry);
            return true;
        }

        public bool UpdateAdminAgenda(Agenda entry)
        {
            var existingEntry = _agenda.FirstOrDefault(a => a.Id_Agenda == entry.Id_Agenda);
            if (existingEntry == null)
            {
                return false; // La entrada no existe, no se puede actualizar
            }

            existingEntry.Fecha = entry.Fecha;
            existingEntry.Description = entry.Description;
            // Actualizar otros campos según sea necesario

            return true;
        }

        public bool DeleteAdminAgenda(int entryId)
        {
            var entry = _agenda.FirstOrDefault(a => a.Id_Agenda == entryId);
            if (entry == null)
            {
                return false; // La entrada no existe, no se puede eliminar
            }

            _agenda.Remove(entry);
            return true;
        }

        // Implementación de métodos genéricos del repositorio

        public int Add(Admin entity)
        {
            _admins.Add(entity);
            return entity.Id;
        }

        public Admin Get(int id)
        {
            return _admins.FirstOrDefault(a => a.Id == id);
        }

        public bool Update(Admin entity)
        {
            var existingAdmin = _admins.FirstOrDefault(a => a.Id == entity.Id);
            if (existingAdmin == null)
            {
                return false; // El admin no existe, no se puede actualizar
            }

            existingAdmin.Name = entity.Name;
            existingAdmin.Email = entity.Email;
            // Actualizar otros campos según sea necesario

            return true;
        }

        public bool Delete(int id)
        {
            var admin = _admins.FirstOrDefault(a => a.Id == id);
            if (admin == null)
            {
                return false; // El admin no existe, no se puede eliminar
            }

            _admins.Remove(admin);
            return true;
        }
    }
}
