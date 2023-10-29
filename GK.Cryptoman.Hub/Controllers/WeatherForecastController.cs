using GK.Cryptoman.Hub.Model;
using GK.Cryptoman.Utilities.Shared.Exception;
using Microsoft.AspNetCore.Mvc;

namespace GK.Cryptoman.Hub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : BaseController
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<PingController> _logger;

        public PingController(ILogger<PingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var retval = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();


            if (retval.Any(x => x.TemperatureC < -10))
                throw new ButtFreezingTemperatureException(System.Net.HttpStatusCode.NotAcceptable, 90001, null, "Butt freezing temperature detected");

            return retval;
        }
    }
}