using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentValidation.Results;
using CricketDataTypes;
using FluentAssertions;

#nullable disable

namespace DataTypesTest
{
    [TestClass]
    public class TestDataTypes
    {

        [TestMethod]
        public void WhenRequestIsMissingEmail_thenValidationFails()
        {
            PitchBookingRequest request = new PitchBookingRequest()
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
            PitchBookingRequest request = new PitchBookingRequest()
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
            PitchBookingRequest request = new PitchBookingRequest()
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
