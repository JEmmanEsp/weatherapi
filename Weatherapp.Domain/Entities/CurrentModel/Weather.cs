using System;
using System.Collections.Generic;
using System.Text;

namespace Weatherapp.Domain.Entities.CurrentModel
{
    public class Weather
    {
        public string icon { get; set; }
        public int code { get; set; }
        public string description { get; set; }
    }
}
