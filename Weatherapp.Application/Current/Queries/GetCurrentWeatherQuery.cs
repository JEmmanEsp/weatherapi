using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Weatherapp.Domain.Entities.CurrentModel;
using Weatherapp.Application.Common;

namespace Weatherapp.Application.Current.Queries
{
    public class GetCurrentWeatherQuery : IRequest<Response<CurrentResponse>>
    {
        public string Location { get; set; }
        public string Units { get; set; }

        public GetCurrentWeatherQuery(string _location, string _units)
        {
            Location = _location;
            Units = _units;
        }
    }
}
