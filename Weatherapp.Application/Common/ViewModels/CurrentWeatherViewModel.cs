using System;
using System.Collections.Generic;
using System.Text;

namespace Weatherapp.Application.Common.ViewModels
{
    public class CurrentWeatherViewModel
    {
        public string Location { get; set; }

        public List<ForecastWeatherViewModel> ForecastWeather { get; set; }
    }
}
