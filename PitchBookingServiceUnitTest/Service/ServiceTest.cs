using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using PitchBookingService.Service;
using FakeItEasy;
using CricketDataTypes;
using PitchBookingService.Integration;
using System.Collections.Generic;
using System;

namespace PitchBookingServiceTest.Service
{
    [TestClass]
    public class ServiceTest
    {

        private PitchBooking BuildBookingForTomorrow()
        {
            return new PitchBooking()
            {
                ContactEmail = "test@test.com",
                BookingDate = System.DateTime.Now.AddDays(1)
            };
        }


        [TestMethod]
        public void WhenIAddASecondBookingForSameDay_ItIsRejectedWithABookingException()
        {
            // ARRANGE
            var repo = A.Fake<IDataRepo>();
            var eventEmitter = A.Fake<IEventEmitter>();
            IBookingService service = new BookingService(repo, eventEmitter);
            var booking = BuildBookingForTomorrow();
            A.CallTo(() => repo.GetBookingByDate(booking.BookingDate)).Returns(booking);

            // ACT AND ASSERT
            service.Invoking(s => s.AddBooking(booking)).Should().Throw<InvalidBookingException>()
                    .WithMessage("This date is already booked");

        }


        [TestMethod]
        public void WhenIAddAValidBooking_ItIsAddedToTheBookingsListAndEventIsFired()
        {
            // ARRANGE
            var repo = A.Fake<IDataRepo>();
            var eventEmitter = A.Fake<IEventEmitter>();
            IBookingService service = new BookingService(repo, eventEmitter);
            var booking = BuildBookingForTomorrow();
            A.CallTo(() => repo.QueryAllBookings()).Returns(new Dictionary<DateTime, PitchBooking>() { { booking.BookingDate, booking } });
            A.CallTo(() => repo.GetBookingByDate(booking.BookingDate)).Returns(null);

            // ACT
            service.AddBooking(booking);
            var bookings = service.GetAllBookings();

            // ASSERT
            bookings.Count.Should().Be(1);
            bookings.Should().OnlyContain(b => b.Value.Equals(booking));
            A.CallTo(() => repo.StoreBooking(booking)).MustHaveHappened();
            A.CallTo(() => eventEmitter.BookingRequestAccepted(booking)).MustHaveHappened();
        }


    }
}
