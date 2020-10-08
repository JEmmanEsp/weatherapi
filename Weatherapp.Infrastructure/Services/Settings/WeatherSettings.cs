using System;
using System.Collections.Generic;
using System.Text;

namespace Weatherapp.Infrastructure.Services.Settings
{
    public class WeatherSettings
    {
        public string Url { get; set; }
        public string AccessKey { get; set; }
        public string Current { get; set; }
        public string Forecast { get; set; }
    }
}
