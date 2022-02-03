using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public class WeatherLocation
    {

        public Int32 distancee { get; set; }
        public string lat_long { get; set; }
        public string location_type { get; set; }
        public string title { get; set; }
        public Int32 woeid { get; set; }

    }
}
