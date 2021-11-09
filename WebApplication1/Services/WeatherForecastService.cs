using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> Get()
        {
            Thread.Sleep(4000);
            var rng = new Random();
            return Enumerable.Range(1, 3).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }

        public Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            return Task.Run(Get);
        }

    }
}
