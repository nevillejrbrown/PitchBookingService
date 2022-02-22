using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentValidation;
using CricketDataTypes;

namespace DataTypesTest
{
    [TestClass]
    public class TestDataTypes
    {
        [TestMethod]
        public void TestValidationEmailMustBePresent()
        {
            PitchBookingRequest request = new PitchBookingRequest()
            {
                ContactEmail = "",
                BookingDate = new System.DateTime()
            };

            PitchBookingRequestValidator validator = new PitchBookingRequestValidator();
       
        }
    }
}
