using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecastService _service;
        private readonly WeatherForecastConverter _converter;

        public WeatherForecastController(WeatherForecastService service, WeatherForecastConverter converter)
        {
            _service = service;
            _converter = converter;
        }

        [HttpGet]
        public IEnumerable<WeatherForecastDto> Get()
        {
            var res1 = _service.Get();
            return _converter.Convert(res1);
        }

        [HttpGet]
        [Route("get_async")]
        public async Task<IEnumerable<WeatherForecastDto>> GetAsync()
        {
            var res1 = await _service.GetAsync();
            return await _converter.ConvertAsync(res1);
        }
    }
}
