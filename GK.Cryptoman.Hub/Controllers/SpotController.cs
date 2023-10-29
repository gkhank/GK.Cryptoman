using GK.Cryptoman.Hub.Model.Request;
using GK.Cryptoman.Utilities.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace GK.Cryptoman.Hub.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SpotController : BaseController
    {
        private readonly ILogger<SpotController> _logger;

        public SpotController(ILogger<SpotController> logger)
        {
            _logger = logger;
        }


        //Returns data for specified currencies from given date.
        [HttpGet]
        public ActionResult<string> Get([FromQuery]SpotRequest spotRequest)
        {
            _logger.LogInformation($"Logger works in Get");
            return Ok("some spots");
        }

        //Returns data for all currencies from given date.
        [HttpGet]
        public ActionResult<string> GetAll([FromQuery] DateTime fromDate, DataFrequencyInterval dataFrequencyInterval)
        {
            _logger.LogInformation($"Logger works in GetAll");
            return Ok("all spots");
        }
    }
}