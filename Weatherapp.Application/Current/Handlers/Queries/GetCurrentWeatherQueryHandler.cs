using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Weatherapp.Domain.Entities.CurrentModel;
using Weatherapp.Application.Common;
using Weatherapp.Application.Current.Queries;
using Weatherapp.Application.Infrastructure.Services;

namespace Weatherapp.Application.Current.Handlers.Queries
{
    public class GetCurrentWeatherQueryHandler : IRequestHandler<GetCurrentWeatherQuery, Response<CurrentResponse>>
    {
        private readonly ICurrentWeatherService _currentWeatherService;

        public GetCurrentWeatherQueryHandler(ICurrentWeatherService currentWeatherService)
        {
            _currentWeatherService = currentWeatherService;
        }

        public async Task<Response<CurrentResponse>> Handle(GetCurrentWeatherQuery request, CancellationToken cancellationToken)
        {
            var response = await _currentWeatherService.GetCurrent();

            return Response.Ok200(response);
        }
    }
}
