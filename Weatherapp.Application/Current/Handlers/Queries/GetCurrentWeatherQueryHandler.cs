using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Weatherapp.Domain.Entities.CurrentModel;
using Weatherapp.Application.Common;
using Weatherapp.Application.Current.Queries;
using Weatherapp.Application.Infrastructure.Services;
using Weatherapp.Application.Common.ViewModels;
using System.Collections.Generic;

namespace Weatherapp.Application.Current.Handlers.Queries
{
    public class GetCurrentWeatherQueryHandler : IRequestHandler<GetCurrentWeatherQuery, Response<CurrentWeatherViewModel>>
    {
        private readonly ICurrentWeatherService _currentWeatherService;
        private readonly string weatherIconUrl = "https://www.weatherbit.io/static/img/icons/";

        public GetCurrentWeatherQueryHandler(ICurrentWeatherService currentWeatherService)
        {
            _currentWeatherService = currentWeatherService;
        }

        public async Task<Response<CurrentWeatherViewModel>> Handle(GetCurrentWeatherQuery request, CancellationToken cancellationToken)
        {
            var response = await _currentWeatherService.GetCurrent(request.Location, request.Units);

            if (response == null || response.Data.Count == 0)
                return Response.Fail500ServiceError<CurrentWeatherViewModel>("Something went wrong. Try again later");

            var forecastWeather = new List<ForecastWeatherViewModel>();
            response.Data.ForEach(data =>
                forecastWeather.Add(new ForecastWeatherViewModel()
                {
                    Date = data.datetime,
                    Temperature = $"{data.temp} {request.UnitDescription}",
                    WeatherDescription = data.weather.description,
                    WeatherIcon = data.weather.icon,
                    WeatherIconCode = data.weather.code,
                    WeatherIconUrl = $"{weatherIconUrl}{data.weather.icon}.png",
                    Humidity = $"{data.rh}%",
                    Wind = $"{data.wind_spd} {request.SpeedUnits}",
                    Precipitation = $"{data.pop}%"
                })
            );

            var result = new CurrentWeatherViewModel()
            {
                Location = $"{response.City_name}, {response.Country_code}",
                ForecastWeather = forecastWeather
            };

            return Response.Ok200(result);
        }
    }
}
