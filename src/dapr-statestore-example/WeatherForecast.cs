using System;

namespace DaprExample.StateStore
{
    public class WeatherForecast
    {
        public string Key => this.Date.ToString("yyyy-MM-dd");
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
