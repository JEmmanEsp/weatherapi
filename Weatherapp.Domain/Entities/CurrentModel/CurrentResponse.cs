using System;
using System.Collections.Generic;
using System.Text;

namespace Weatherapp.Domain.Entities.CurrentModel
{
    public class CurrentResponse
    {
        public List<Data> Data { get; set; }
        public string City_name { get; set; }
        public string Country_code { get; set; }
    }
}
