using Business.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HeliBaja.Controllers
{
    public class BookingController : ApiController
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookings();
            return Ok(bookings);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetBookingById(int bookingId)
        {
            var booking = await _bookingService.GetBookingById(bookingId);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddBooking(Booking booking)
        {
            var bookingId = await _bookingService.AddBooking(booking);
            return Ok(bookingId);
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateBooking(int bookingId, Booking booking)
        {
            if (bookingId != booking.Id_Booking)
            {
                return BadRequest("Invalid booking ID");
            }

            var result = await _bookingService.UpdateBooking(booking);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteBooking(int bookingId)
        {
            var result = await _bookingService.DeleteBooking(bookingId);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpGet]
        public IHttpActionResult GetBookingsByClient(int clientId)
        {
            var bookings = _bookingService.GetBookingsByClient(clientId);
            return Ok(bookings);
        }

        [HttpGet]
        public IHttpActionResult GetBookingsByFlight(int flightId)
        {
            var bookings = _bookingService.GetBookingsByFlight(flightId);
            return Ok(bookings);
        }
    }
}