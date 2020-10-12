using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Weatherapp.Application.Current.Queries;
using Weatherapp.Application.Infrastructure.Services;
using Weatherapp.Domain.Entities.CurrentModel;
using Weatherapp.Application.Current.Handlers.Queries;
using Weatherapp.Application.Common.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Weatherapp.Application.UnitTests.HandlerTests.CurrentWeatherHandlers
{
    [TestFixture]
    public class GetCurrentWeatherQueryHandlerTest
    {
        private Mock<ICurrentWeatherService> _serviceMock;
        private CurrentResponse currentResponse;

        [SetUp]
        public void Setup()
        {
            _serviceMock = new Mock<ICurrentWeatherService>();
            var data = new List<Data>()
            {
                new Data()
                {
                    datetime = "2020-10-12",
                    pop = 26.5,
                    rh = 13.2,
                    temp = 16.6,
                    wind_cdir_full = "NEW",
                    wind_spd = 16.6,
                    weather = new Weather()
                    {
                        code = 301,
                        description = "break clouds",
                        icon = "c01d"
                    }
                }
            };

            currentResponse = new CurrentResponse()
            {
                City_name = "Los Mochis",
                Country_code = "MX",
                Data = data
            };
        }

        [Test]
        [TestCase("zapopan", "m")]
        [TestCase("los mochis", "i")]
        public void GetCurrentWeather_ReturnCurrentWeatherViewModel_Successful(string location, string units)
        {
            _serviceMock
                .Setup(service => service.GetCurrent(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(currentResponse);
            var query = new GetCurrentWeatherQueryHandler(_serviceMock.Object);

            var response = query.Handle(new GetCurrentWeatherQuery(location, units), default);
            var result = response.Result.Data;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<CurrentWeatherViewModel>(result);
        }

        [Test]
        [TestCase("zapopan", "m")]
        [TestCase("los mochis", "i")]
        public void GetCurrentWeather_ReturnCurrentWeatherViewModel_Fail(string location, string units)
        {
            _serviceMock
                .Setup(service => service.GetCurrent(It.IsAny<string>(), It.IsAny<string>()));
            var query = new GetCurrentWeatherQueryHandler(_serviceMock.Object);

            var response = query.Handle(new GetCurrentWeatherQuery(location, units), default);
            var result = response.Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, result.StatusCode);
        }
    }
}
