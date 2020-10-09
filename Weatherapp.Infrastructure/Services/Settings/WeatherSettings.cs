using System;
using System.Collections.Generic;
using System.Text;

namespace Weatherapp.Infrastructure.Services.Settings
{
    public class WeatherSettings
    {
        public string Url { get; set; }

        public string ForecastUrl { get; set; }

        public string AccessKey { get; set; }

        public string Days { get; set; }

        public string City { get; set; }
    }
}
