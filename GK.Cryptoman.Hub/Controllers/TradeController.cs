using Microsoft.AspNetCore.Mvc;

namespace GK.Cryptoman.Hub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TradeController : ControllerBase
    {
        private readonly ILogger<TradeController> _logger;

        public TradeController(ILogger<TradeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            _logger.LogInformation($"Logger works in {this}");
            return Ok("aa");
        }
    }
}