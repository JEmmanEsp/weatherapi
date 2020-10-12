using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weatherapp.Application.Infrastructure.Services;
using Weatherapp.Domain.Entities.CurrentModel;

namespace Weatherapp.Infrastructure.UnitTests.Services
{
    [TestFixture]
    public class CurrentWeatherServiceTests
    {
        private Mock<ICurrentWeatherService> _serviceMock;

        [SetUp]
        public void Setup()
        {
            _serviceMock = new Mock<ICurrentWeatherService>();
        }

        [Test]
        [TestCase("zapopan", "m")]
        public async Task GetCurrentWeather_ReturnCurrentResponse_Successfully(string location, string units)
        {
            _serviceMock
                .Setup(service => service.GetCurrent(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new CurrentResponse());

            var result = await _serviceMock.Object.GetCurrent(location, units);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<CurrentResponse>(result);
        }

        [Test]
        [TestCase("tonala", "i")]
        public async Task GetCurrentWeather_NotFound(string location, string units)
        {
            _serviceMock
                .Setup(service => service.GetCurrent(It.IsAny<string>(), It.IsAny<string>()));

            var result = await _serviceMock.Object.GetCurrent(location, units);

            Assert.IsNull(result);
        }

    }
}
