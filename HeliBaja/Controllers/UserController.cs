using Business.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace HeliBaja.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IHttpActionResult AddUser(Users user)
        {
            int userId = _userService.AddUser(user);
            return Ok(userId);
        }

        [HttpPut]
        public IHttpActionResult UpdateUser(Users user)
        {
            bool success = _userService.UpdateUser(user);
            if (success)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteUser(int userId)
        {
            bool success = _userService.DeleteUser(userId);
            if (success)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IHttpActionResult GetUserById(int userId)
        {
            Users user = _userService.GetUserById(userId);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IHttpActionResult GetUserByEmail(string email)
        {
            Users user = _userService.GetUserByEmail(email);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IHttpActionResult GetAllUsers()
        {
            List<Users> users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet]
        public IHttpActionResult GetUserBookings(int userId)
        {
            List<Booking> bookings = _userService.GetUserBookings(userId);
            return Ok(bookings);
        }

        [HttpGet]
        public IHttpActionResult GetAvailableFlights()
        {
            List<Flight> flights = _userService.GetAvailableFlights();
            return Ok(flights);
        }

        [HttpPost]
        public IHttpActionResult BookFlight(int userId, int flightId)
        {
            bool success = _userService.BookFlight(userId, flightId);
            if (success)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public IHttpActionResult CancelBooking(int bookingId)
        {
            bool success = _userService.CancelBooking(bookingId);
            if (success)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IHttpActionResult GetAdminUsers()
        {
            List<Users> adminUsers = _userService.GetAdminUsers();
            return Ok(adminUsers);
        }

        [HttpGet]
        public IHttpActionResult GetAdminUserById(int userId)
        {
            Users adminUser = _userService.GetAdminUserById(userId);
            if (adminUser != null)
            {
                return Ok(adminUser);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IHttpActionResult AddAdminUser(Users user)
        {
            bool success = _userService.AddAdminUser(user);
            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateAdminUser(Users user)
        {
            bool success = _userService.UpdateAdminUser(user);
            if (success)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteAdminUser(int userId)
        {
            bool success = _userService.DeleteAdminUser(userId);
            if (success)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}