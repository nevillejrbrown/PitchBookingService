using CricketDataTypes;
using System;
using System.Collections.Generic;
using PitchBookingService.Integration;

namespace PitchBookingService.Service
{
    public class BookingService : IBookingService
    {
        IDataRepo _dataRepo;
        IEventEmitter _eventEmitter;

        public BookingService(IDataRepo dataRepo, IEventEmitter eventEmitter)
        {
            this._dataRepo = dataRepo;
            this._eventEmitter = eventEmitter;
        }

        public IDictionary<DateTime, PitchBooking> GetAllBookings()
        {
            var bookings = _dataRepo.QueryAllBookings();
            return bookings;
        }

        public void AddBooking(PitchBooking booking)
        {
            if (_dataRepo.GetBookingByDate(booking.BookingDate) != null)
            {
                throw new InvalidBookingException("This date is already booked");
            }
            _dataRepo.StoreBooking(booking);
            _eventEmitter.BookingRequestAccepted(booking);
        }
    }
}
