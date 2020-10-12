using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Weatherapp.Api.Controllers;
using Weatherapp.Application.Common;
using Weatherapp.Application.Common.ViewModels;
using Weatherapp.Application.Current.Queries;

namespace Weatherapp.Api.UnitTests.Controllers.CurrentWeather
{
    [TestFixture]
    public class CurrentWeatherControllerTest
    {
        private Mock<IMediator> _mediator;
        private CurrentWeatherController _controller;
        private CurrentWeatherViewModel _currentWeather;

        [SetUp]
        public void Setup()
        {
            _mediator = new Mock<IMediator>();
            _controller = new CurrentWeatherController(_mediator.Object);

            var forecast = new List<ForecastWeatherViewModel>()
            {
                new ForecastWeatherViewModel()
                {
                    Date = "2020-10-12",
                    Humidity = "20%",
                    Precipitation = "12%",
                    Temperature = "22 C",
                    WeatherDescription = "",
                    WeatherIcon = "",
                    WeatherIconCode = 102,
                    WeatherIconUrl = "",
                    Wind = ""
                }
            };
            _currentWeather = new CurrentWeatherViewModel()
            {
                Location = "Zapopan",
                ForecastWeather = forecast
            };
        }

        [Test]
        [TestCase("zapopan", "m")]
        [TestCase("los mochis", "i")]
        public void Get_ReturnCurrentWeatherViewModel_Successful(string location, string units)
        {
            _mediator
                .Setup(val => val.Send(It.IsAny<GetCurrentWeatherQuery>(), default))
                .ReturnsAsync(Response.Ok200(_currentWeather));

            var response = _controller.Get(location, units);
            var result = (ObjectResult)response.Result.Result;
            var currentWeather = (Response<CurrentWeatherViewModel>)result.Value;

            Assert.IsNotNull(currentWeather);
            Assert.AreEqual(StatusCodes.Status200OK, currentWeather.StatusCode);
        }

        [Test]
        [TestCase("zapopan", "m")]
        [TestCase("los mochis", "i")]
        public void Get_ReturnCurrentWeatherViewModel_Fail(string location, string units)
        {
            _mediator
                .Setup(val => val.Send(It.IsAny<GetCurrentWeatherQuery>(), default))
                .ReturnsAsync(Response.Fail500ServiceError<CurrentWeatherViewModel>(""));

            var response = _controller.Get(location, units);
            var result = (ObjectResult)response.Result.Result;
            var currentWeather = (Response<CurrentWeatherViewModel>)result.Value;

            Assert.IsNull(currentWeather.Data);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, currentWeather.StatusCode);
        }

    }
}
