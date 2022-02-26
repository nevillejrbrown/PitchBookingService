using System.Collections.Generic;
using CricketDataTypes;
using System;

namespace PitchBookingService.Service
{
    public interface IBookingService
    {
        public IDictionary<DateTime, PitchBooking> GetAllBookings();

        public void AddBooking(PitchBooking booking);

    }
}
