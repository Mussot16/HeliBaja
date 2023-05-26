using Domain.Model;
using Business.Contracts;
using System.Collections.Generic;
using System.Web.Http;

namespace HeliBaja.Controllers
{
    public class AdminController : ApiController
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        // Admin

        // GET: api/admins
        [HttpGet]
        public IHttpActionResult GetAdmins()
        {
            List<Admin> admins = _adminService.GetAdmins();
            return Ok(admins);
        }

        // GET: api/admins/{adminId}
        [HttpGet]
        public IHttpActionResult GetAdminById(int adminId)
        {
            Admin admin = _adminService.GetAdminById(adminId);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }

        // POST: api/admins
        [HttpPost]
        public IHttpActionResult AddAdmin(Admin admin)
        {
            bool result = _adminService.AddAdmin(admin);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/admins/{adminId}
        [HttpPut]
        public IHttpActionResult UpdateAdmin(int adminId, Admin admin)
        {
            if (adminId != admin.Id)
            {
                return BadRequest();
            }

            bool result = _adminService.UpdateAdmin(admin);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE: api/admins/{adminId}
        [HttpDelete]
        public IHttpActionResult DeleteAdmin(int adminId)
        {
            bool result = _adminService.DeleteAdmin(adminId);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        // Booking

        // GET: api/admins/bookings
        [HttpGet]
        public IHttpActionResult GetAdminBookings()
        {
            List<Booking> bookings = _adminService.GetAdminBookings();
            return Ok(bookings);
        }

        // POST: api/admins/bookings
        [HttpPost]
        public IHttpActionResult AddAdminBooking(Booking booking)
        {
            bool result = _adminService.AddAdminBooking(booking);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/admins/bookings/{bookingId}
        [HttpPut]
        public IHttpActionResult UpdateAdminBooking(int bookingId, Booking booking)
        {
            if (bookingId != booking.Id_Booking)
            {
                return BadRequest();
            }

            bool result = _adminService.UpdateAdminBooking(booking);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE: api/admins/bookings/{bookingId}
        [HttpDelete]
        public IHttpActionResult DeleteAdminBooking(int bookingId)
        {
            bool result = _adminService.DeleteAdminBooking(bookingId);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        // Flight

        // GET: api/admins/flights
        [HttpGet]
        public IHttpActionResult GetAdminFlights()
        {
            List<Flight> flights = _adminService.GetAdminFlights();
            return Ok(flights);
        }

        // POST: api/admins/flights
        [HttpPost]
        public IHttpActionResult AddAdminFlight(Flight flight)
        {
            bool result = _adminService.AddAdminFlight(flight);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/admins/flights/{flightId}
        [HttpPut]
        public IHttpActionResult UpdateAdminFlight(int flightId, Flight flight)
        {
            if (flightId != flight.Id_Flight)
            {
                return BadRequest();
            }

            bool result = _adminService.UpdateAdminFlight(flight);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE: api/admins/flights/{flightId}
        [HttpDelete]
        public IHttpActionResult DeleteAdminFlight(int flightId)
        {
            bool result = _adminService.DeleteAdminFlight(flightId);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        // User

        // GET: api/admins/users
        [HttpGet]
        public IHttpActionResult GetAdminUsers()
        {
            List<Users> users = _adminService.GetAdminUsers();
            return Ok(users);
        }

        // GET: api/admins/users/{userId}
        [HttpGet]
        public IHttpActionResult GetAdminUserById(int userId)
        {
            Users user = _adminService.GetAdminUserById(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/admins/users
        [HttpPost]
        public IHttpActionResult AddAdminUser(Users user)
        {
            bool result = _adminService.AddAdminUser(user);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/admins/users/{userId}
        [HttpPut]
        public IHttpActionResult UpdateAdminUser(int userId, Users user)
        {
            if (userId != user.Id)
            {
                return BadRequest();
            }

            bool result = _adminService.UpdateAdminUser(user);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE: api/admins/users/{userId}
        [HttpDelete]
        public IHttpActionResult DeleteAdminUser(int userId)
        {
            bool result = _adminService.DeleteAdminUser(userId);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        // Inventory

        // GET: api/admins/inventory
        [HttpGet]
        public IHttpActionResult GetAdminInventory()
        {
            List<Inventory> inventory = _adminService.GetAdminInventory();
            return Ok(inventory);
        }

        // GET: api/admins/inventory/{itemId}
        [HttpGet]
        public IHttpActionResult GetAdminInventoryById(int itemId)
        {
            Inventory item = _adminService.GetAdminInventoryById(itemId);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST: api/admins/inventory
        [HttpPost]
        public IHttpActionResult AddAdminInventory(Inventory item)
        {
            bool result = _adminService.AddAdminInventory(item);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/admins/inventory/{itemId}
        [HttpPut]
        public IHttpActionResult UpdateAdminInventory(int itemId, Inventory item)
        {
            if (itemId != item.Id_Inventory)
            {
                return BadRequest();
            }

            bool result = _adminService.UpdateAdminInventory(item);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE: api/admins/inventory/{itemId}
        [HttpDelete]
        public IHttpActionResult DeleteAdminInventory(int itemId)
        {
            bool result = _adminService.DeleteAdminInventory(itemId);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        // Agenda

        // GET: api/admins/agenda
        [HttpGet]
        public IHttpActionResult GetAdminAgenda()
        {
            List<Agenda> agenda = _adminService.GetAdminAgenda();
            return Ok(agenda);
        }

        // GET: api/admins/agenda/{entryId}
        [HttpGet]
        public IHttpActionResult GetAdminAgendaById(int entryId)
        {
            Agenda entry = _adminService.GetAdminAgendaById(entryId);
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }

        // POST: api/admins/agenda
        [HttpPost]
        public IHttpActionResult AddAdminAgenda(Agenda entry)
        {
            bool result = _adminService.AddAdminAgenda(entry);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/admins/agenda/{entryId}
        [HttpPut]
        public IHttpActionResult UpdateAdminAgenda(int entryId, Agenda entry)
        {
            if (entryId != entry.Id_Agenda)
            {
                return BadRequest();
            }

            bool result = _adminService.UpdateAdminAgenda(entry);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE: api/admins/agenda/{entryId}
        [HttpDelete]
        public IHttpActionResult DeleteAdminAgenda(int entryId)
        {
            bool result = _adminService.DeleteAdminAgenda(entryId);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}