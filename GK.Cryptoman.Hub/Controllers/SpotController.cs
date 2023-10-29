using CryptoExchange.Net.Objects;
using GK.Cryptoman.Hub.Model.Request;
using GK.Cryptoman.Utilities.Shared.Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.ComponentModel.DataAnnotations;
using ValidationException = GK.Cryptoman.Utilities.Shared.Exception.ValidationException;

namespace GK.Cryptoman.Hub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpotController : ControllerBase
    {
        private readonly ILogger<SpotController> _logger;

        public SpotController(ILogger<SpotController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<string> Get(string? spots)
        {
            var spotsCollection = new SpotRequest
            {
                Spots = spots?.Split(',')
            };

            _logger.LogInformation($"Logger works in {this}");
            return Ok("some spots");
        }

        [HttpGet]
        [Route("all")]
        public ActionResult<string> GetAll()
        {
            _logger.LogInformation($"Logger works in GetAll");
            return Ok("all spots");
        }
    }
}