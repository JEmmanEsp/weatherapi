using System;
using System.Collections.Generic;
using System.Text;

namespace Weatherapp.Application.Common.ViewModels
{
    public class CurrentWeatherViewModel
    {
        public string Date { get; set; }

        public string Location { get; set; }

        public string Temperature { get; set; }

        public List<string> Descriptions { get; set; }

        public List<string> WeatherIcon { get; set; }
    }
}
