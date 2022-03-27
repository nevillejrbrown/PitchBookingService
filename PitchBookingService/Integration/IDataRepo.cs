using System;
using System.Collections.Generic;
using CricketDataTypes;

namespace PitchBookingService.Integration

{
    public interface IDataRepo
    {
        public void StoreBooking(PitchBooking request);

        public IDictionary<DateTime, PitchBooking> QueryAllBookings();

        public PitchBooking GetBookingByDate(DateTime bookingDate);

    }
}
