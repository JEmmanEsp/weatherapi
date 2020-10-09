using System;
using System.Collections.Generic;
using System.Text;

namespace Weatherapp.Domain.Entities.CurrentModel
{
    public class Data
    {
        public Weather weather { get; set; }

        public string datetime { get; set; }

        public double temp { get; set; }

        public double rh { get; set; }

        public double wind_spd { get; set; }

        public string wind_cdir_full { get; set; }

        public double pop { get; set; }
    }
}
