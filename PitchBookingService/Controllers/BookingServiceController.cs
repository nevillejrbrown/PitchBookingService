using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using PitchBookingService.Service;
using CricketDataTypes;

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
        public void Post(PitchBooking booking) 
        {
            _bookingService.AddBooking(booking);
        }
    }
}
