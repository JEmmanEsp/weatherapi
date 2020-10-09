using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Weatherapp.Domain.Entities.CurrentModel;
using Weatherapp.Application.Common;
using Weatherapp.Application.Common.ViewModels;

namespace Weatherapp.Application.Current.Queries
{
    public class GetCurrentWeatherQuery : IRequest<Response<CurrentWeatherViewModel>>
    {
        public string Location { get; set; }
        public string Units { get; set; }
        public string UnitDescription { get; set; }

        public GetCurrentWeatherQuery(string _location, string _units)
        {
            Location = _location;
            Units = _units;
            UnitDescription = (Units == "m") ? "Celsius" : "Fahrenheit";
        }
    }
}
