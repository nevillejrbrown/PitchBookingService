using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PitchBookingService.Service;
using PitchBookingService.Controllers;
using PitchBookingService.Integration;
using CricketDataTypes;
using System.Collections;
using FluentAssertions;

namespace PitchBookingServiceIntegrationTests
{
    [TestClass]
    public class EndToEndPitchBookingTest
    {

        BookingServiceController _controller;

        public EndToEndPitchBookingTest()
        {
            // create and configure an instance of the controller
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                    services.AddScoped<IBookingService, BookingService>()
                            .AddSingleton<IDataRepo, FakeDataRepo>()
                            .AddSingleton<IEventEmitter, EventGridEmitter>()).Build();

            using var serviceScope = host.Services.CreateScope();
            var provider = serviceScope.ServiceProvider;
            var service = provider.GetRequiredService<IBookingService>();

            _controller = new BookingServiceController(null, service);
        }



        [TestMethod]
        public void TestMethod1()
        {

            PitchBooking request = new PitchBooking()
            {
                ContactEmail = "",
                BookingDate = System.DateTime.Now.AddDays(1)
            };
            _controller.Get().Should().HaveCount(0);
            _controller.Post(request);
            _controller.Get().Should().HaveCount(1);

        }
    }
}
