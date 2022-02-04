using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public class WeatherLocationDetail
    {
        public float Air_Pressure { get; set; }
        public DateTime Applicable_Date { get; set; }
        public float Humidity { get; set; }
        public Int64 ID { get; set; }
        public Int64 Max_Temp { get; set; }
        public Int64 Min_Temp { get; set; }
        public Int32 Predictability { get; set; }
        public Int64 The_Temp { get; set; }
        public float? Visibility { get; set; }
        public string Weather_State_Abbr { get; set; }
        public string Weather_State_Name { get; set; }
        public string Wind_Direction { get; set; }
        public string Wind_Direction_Compass { get; set; }
        public string Wind_Speed { get; set; }
    }
}
