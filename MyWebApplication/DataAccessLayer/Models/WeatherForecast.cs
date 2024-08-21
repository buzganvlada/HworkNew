using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


public class WeatherForecast
{
    public int ID { get; set; }
    public DateTime Date { get; set; }

    public int Temperature { get; set; }

    public int TemperatureF => 32 + (int)(Temperature / 0.5556);

    public string Summary { get; set; }
}
