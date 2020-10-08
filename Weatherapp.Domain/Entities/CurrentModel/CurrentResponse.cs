using System;
using System.Collections.Generic;
using System.Text;

namespace Weatherapp.Domain.Entities.CurrentModel
{
    public class CurrentResponse
    {
        public Request Request { get; set; }

        public Location Location { get; set; }

        public Current Current { get; set; }
    }
}
