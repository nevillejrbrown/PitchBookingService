using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using RestSharp;
using static System.Net.HttpStatusCode;

namespace APITests
{
    [TestClass]
    public class PitchBookingServiceAPITests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var client = new RestClient("https://pitchbookingservice.azurewebsites.net");
            var request = new RestRequest("BookingService");
            var response = client.Get(request);
            response.StatusCode.Should().Be(OK);
        }
    }
}
