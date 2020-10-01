using System;

namespace DaprExample.StateStore
{
    public class WeatherRequest
    {
        public DateTime Date { get; set; }
        public string Key => this.Date.ToString("yyyy-MM-dd");
    }
}
