using System;
using System.Collections.Generic;
using System.Text;

namespace Weatherapp.Domain.Entities.CurrentModel
{
    public class Current
    {
        public string Observation_time { get; set; }

        public int Temperature { get; set; }

        public int Weather_code { get; set; }

        public List<string> Weather_icons { get; set; }

        public List<string> Weather_descriptions { get; set; }

        public int Wind_speed { get; set; }

        public int Wind_degree { get; set; }

        public string Wind_dir { get; set; }

        public int Pressure { get; set; }

        public int Precip { get; set; }

        public int Humidity { get; set; }

        public int Feelslike { get; set; }
    }
}
