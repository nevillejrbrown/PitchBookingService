﻿using System.Collections.Generic;
using System;
using CricketDataTypes;

#nullable enable

namespace PitchBookingService.Integration
{

    public class FakeDataRepo : IDataRepo
    {

        private IDictionary<DateTime, PitchBooking> bookings = new Dictionary<DateTime, PitchBooking>();

        public PitchBooking? GetBookingByDate(DateTime bookingDate)
        {
            PitchBooking? bookingFound;
            return bookings.TryGetValue(bookingDate, out bookingFound) ? bookingFound : null;
        }

        public IDictionary<DateTime, PitchBooking> QueryAllBookings()
        {
            return bookings;
        }

        public void StoreBooking(PitchBooking request)
        {
            bookings.Add(request.BookingDate, request);
        }
    }
}
