using CricketDataTypes;

namespace PitchBookingService.Integration

{
    public interface IEventEmitter
    {
        public void BookingRequestAccepted(PitchBooking booking);


    }
}
