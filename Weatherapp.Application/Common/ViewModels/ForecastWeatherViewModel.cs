using System;
using System.Collections.Generic;
using System.Text;

namespace Weatherapp.Application.Common.ViewModels
{
    public class ForecastWeatherViewModel
    {
        public string Date { get; set; }

        public string Temperature { get; set; }

        public string WeatherDescription { get; set; }

        public string WeatherIcon { get; set; }

        public int WeatherIconCode { get; set; }

        public string WeatherIconUrl { get; set; }

        public string Humidity { get; set; }

        public string Wind { get; set; }

        public string Precipitation { get; set; }
    }
}
