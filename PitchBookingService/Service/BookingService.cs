using CricketDataTypes;
using System;
using System.Collections.Generic;

namespace PitchBookingService.Service
{
    public class BookingService : IBookingService
    {

        private IDictionary<DateTime, PitchBooking> bookings = new Dictionary<DateTime, PitchBooking>();

        public IDictionary<DateTime, PitchBooking> GetAllBookings()
        {
            return bookings;
        }

        public void AddBooking(PitchBooking booking)
        {
            bookings.Add(booking.BookingDate, booking);
        }
    }
}
