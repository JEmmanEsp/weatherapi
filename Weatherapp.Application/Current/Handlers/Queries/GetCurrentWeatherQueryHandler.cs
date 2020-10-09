using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Weatherapp.Domain.Entities.CurrentModel;
using Weatherapp.Application.Common;
using Weatherapp.Application.Current.Queries;
using Weatherapp.Application.Infrastructure.Services;
using Weatherapp.Application.Common.ViewModels;

namespace Weatherapp.Application.Current.Handlers.Queries
{
    public class GetCurrentWeatherQueryHandler : IRequestHandler<GetCurrentWeatherQuery, Response<CurrentWeatherViewModel>>
    {
        private readonly ICurrentWeatherService _currentWeatherService;

        public GetCurrentWeatherQueryHandler(ICurrentWeatherService currentWeatherService)
        {
            _currentWeatherService = currentWeatherService;
        }

        public async Task<Response<CurrentWeatherViewModel>> Handle(GetCurrentWeatherQuery request, CancellationToken cancellationToken)
        {
            var response = await _currentWeatherService.GetCurrent(request.Location, request.Units);

            if (response.Current == null || response.Location == null || response.Request == null)
                return Response.Fail500ServiceError<CurrentWeatherViewModel>("Something went wrong. Try again later");

            var result = new CurrentWeatherViewModel()
            {
                Date = response.Location.Localtime.Split(" ")[0],
                Descriptions = response.Current.Weather_descriptions,
                WeatherIcon = response.Current.Weather_icons,
                Location = $"{response.Location.Name}, {response.Location.Region}, {response.Location.Country}",
                Temperature = $"{response.Current.Temperature} {request.UnitDescription}"
            };

            return Response.Ok200(result);
        }
    }
}
