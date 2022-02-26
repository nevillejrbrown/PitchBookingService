using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using PitchBookingService.Service;
using System.Collections.Generic;
using CricketDataTypes;

namespace PitchBookingServiceTest.Service
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void WhenIAddABooking_ItIsAddedToTheBookingsList()
        {
            IBookingService service = new BookingService();

            var booking = new PitchBooking()
            {
                ContactEmail = "test@test.com",
                BookingDate = System.DateTime.Now.AddDays(1)
            };

            service.AddBooking(booking);

            var bookings = service.GetAllBookings();
            bookings.Count.Should().Be(1);
            bookings.Should().OnlyContain(b => b.Value.Equals(booking));

        }


    }
}
