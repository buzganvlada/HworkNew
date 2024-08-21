using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private List<WeatherForecast> Summaries = new List<WeatherForecast>
        {
            new WeatherForecast { Date = DateTime.Now.AddDays(1), Temperature = 25, Summary = "Hot" },
            new WeatherForecast { Date = DateTime.Now.AddDays(2), Temperature = 15, Summary = "Cold" },
            new WeatherForecast { Date = DateTime.Now.AddDays(3), Temperature = 20, Summary = "Warm" },
            new WeatherForecast { Date = DateTime.Now.AddDays(4), Temperature = 30, Summary = "Very Hot" },
            new WeatherForecast { Date = DateTime.Now.AddDays(5), Temperature = 10, Summary = "Very Cold" }
        };


        public void Create(WeatherForecast weather)
        {
            var weatherFromList = Summaries.FirstOrDefault(x => x.Summary == weather.Summary);
            if (weatherFromList == null)
            {
                Summaries.Add(weather);
            }

            throw new Exception("Already Exists");
        }

        public void DeleteByName(string summary)
        {
            var weather = Summaries.FirstOrDefault(x => x.Summary == summary);
            if (weather == null)
            {
                throw new Exception("Not Found");
            }

            Summaries.Remove(weather);
        }

        public IEnumerable<WeatherForecast> GetAll()
        {
            return Summaries;
        }

        public WeatherForecast GetByName(string summary)
        {
            var weather = Summaries.FirstOrDefault(x => x.Summary == summary);
            if (weather == null)
            {
                throw new Exception("Not Found");
            }

            return weather;
        }

        public void Update(WeatherForecast weather)
        {
            var index = Summaries.FindIndex(x => x.Summary == weather.Summary);
            if (index == -1)
            {
                throw new Exception("Not Found");
            }

            Summaries[index].Date = weather.Date;
            Summaries[index].Temperature = weather.Temperature;
        }
    }
}
