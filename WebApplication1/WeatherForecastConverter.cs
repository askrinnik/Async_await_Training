using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Services;

namespace WebApplication1
{
    public class WeatherForecastConverter
    {
        public IEnumerable<WeatherForecastDto> Convert(IEnumerable<WeatherForecast> forecastList)
        {
            Thread.Sleep(2000);
            return forecastList.Select(forecast =>
                new WeatherForecastDto
                {
                    Date = forecast.Date.ToShortDateString(),
                    Summary = forecast.Summary,
                    TemperatureF = forecast.TemperatureF
                }
            );
        }

        public Task<IEnumerable<WeatherForecastDto>> ConvertAsync(IEnumerable<WeatherForecast> forecastList)
        {
            return Task.Run(() => Convert(forecastList));
        }
    }
}
