﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Weatherapp.Domain.Entities
{
    public class Request
    {
        public string Type { get; set; }
        public string Query { get; set; }
        public string Language { get; set; }
        public string Unit { get; set; }
    }
}
