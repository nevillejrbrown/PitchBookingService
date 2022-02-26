using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentValidation.Results;
using CricketDataTypes;
using FluentAssertions;

namespace DataTypesTest
{
    [TestClass]
    public class TestDataTypes
    {

        [TestMethod]
        public void WhenRequestIsMissingEmail_thenValidationFails()
        {
            PitchBooking request = new PitchBooking()
            {
                ContactEmail = "",
                BookingDate = System.DateTime.Now.AddDays(1)
            };
            ValidationResult result = new PitchBookingRequestValidator().Validate(request);
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(2);
        }

        [TestMethod]
        public void WhenRequestHasDateInPast_thenValidationFails()
        {
            PitchBooking request = new PitchBooking()
            {
                ContactEmail = "test@test.com",
                BookingDate = System.DateTime.Now.AddDays(-1)
            };
            ValidationResult result = new PitchBookingRequestValidator().Validate(request);
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
        }

        [TestMethod]
        public void WhenRequestHasInvalidEmailAndDateInPast_thenValidationFails()
        {
            PitchBooking request = new PitchBooking()
            {
                ContactEmail = "testtest.com",
                BookingDate = System.DateTime.Now.AddDays(-1)
            };
            ValidationResult result = new PitchBookingRequestValidator().Validate(request);
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(2);
        }
        
    }
}
