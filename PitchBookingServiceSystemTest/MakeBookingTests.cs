using Microsoft.VisualStudio.TestTools.UnitTesting;
using RA;
namespace PitchBookingServiceSystemTest
{
    [TestClass]
    public class MakeBookingTests
    {
        private readonly string _Host = "pitchbookingservice.azurewebsites.net";

        [TestMethod]
        public void TestBasicPost()
        {
            new RestAssured().
                Given()
                    .Body("{\"ContactEmail\" : \"blah@blah.com\",\"BookingDate\" : \"2023-04-24T18:29:43-05:00\"}")
                    .Host(_Host)
                    .Uri("/BookingService")
                .When()
                    .Post()
                .Then()
                    .TestStatus("Status should be 200", c => c == 200);

        }
    }
}
