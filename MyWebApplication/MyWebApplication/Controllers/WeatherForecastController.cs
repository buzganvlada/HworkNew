using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IWeatherForecastRepository weatherForecastRepository)
        {
            _logger = logger;
            _weatherForecastRepository = weatherForecastRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> GetAll()
        {
            return _weatherForecastRepository.GetAll();
        }

        [HttpGet("{summary}", Name = "GetWeatherForecastByName")]
        public IActionResult GetpByName(string summary)
        {
            try
            {
                var weather = _weatherForecastRepository.GetByName(summary);
                return Ok(weather);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost(Name = "CreateWeatherForecast")]
        public IActionResult Create([FromBody] WeatherForecast weather)
        {
            try
            {
                _weatherForecastRepository.Create(weather);
                return CreatedAtRoute("GetWeatherForecastByName", new { weather.Summary }, weather);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// Create a new endpoint that will create multiple weather forecasts

        [HttpDelete("{summary}", Name = "DeleteWeatherForecastByName")]
        public IActionResult DeleteByName(string summary)
        {
            try
            {
                _weatherForecastRepository.DeleteByName(summary);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut(Name = "UpdateWeatherForecast")]
        public IActionResult Update(WeatherForecast weatherForecast)
        {
            try
            {
                _weatherForecastRepository.Update(weatherForecast);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}