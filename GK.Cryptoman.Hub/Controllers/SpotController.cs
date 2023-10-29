using CryptoExchange.Net.Objects;
using GK.Cryptoman.Utilities.Shared.Exception;
using Microsoft.AspNetCore.Mvc;
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
            var spotsCollection = spots?.Split(',');
            if (spots is null || spotsCollection?.Length <= 0)
            {
                throw new ValidationException(System.Net.HttpStatusCode.BadRequest, 10001, "No spots were requested");
            }

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