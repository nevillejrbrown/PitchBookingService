using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using PitchBookingService.Service;
using CricketDataTypes;
using System.Threading.Tasks;

namespace PitchBookingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingServiceController : ControllerBase
    {

        private readonly ILogger<BookingServiceController> _logger;
        private readonly IBookingService _bookingService;

        public BookingServiceController(ILogger<BookingServiceController> logger, IBookingService bookingService)
        {
            _logger = logger;
            _bookingService = bookingService;
        }

        [HttpGet]
        public IEnumerable<PitchBooking> Get()
        {
            return _bookingService.GetAllBookings().Values;
        }

        [HttpPost]
        public IActionResult Post(PitchBooking booking) 
        {
            if (!new PitchBookingRequestValidator().Validate(booking).IsValid)
            {
                return BadRequest();
            }
            _bookingService.AddBooking(booking);
            return Ok();
        }
    }
}
