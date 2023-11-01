using Binance.Net.Objects.Models.Spot;
using GK.Cryptoman.Model;
using GK.Cryptoman.Model.Request;
using GK.Cryptoman.Model.Response;
using GK.Cryptoman.Utilities.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GK.Cryptoman.Hub.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SpotController : BaseController
    {
        private readonly ILogger<SpotController> _logger;
        private readonly ISpotRepository _spotRepository;

        public SpotController(
            ILogger<SpotController> logger,
            ISpotRepository spotRepository)
        {
            _logger = logger;
            _spotRepository = spotRepository;
        }


        //Returns data for specified currencies from given date.
        [HttpGet]
        public async Task<BinanceAccountInfo> GetAccountInfo(CancellationToken token)
        {
            _logger.LogInformation($"Logger works in Get");
            return await _spotRepository.GetAccountInfo(token);
        }

        //Returns data for all currencies from given date.
        [HttpGet]
        public ActionResult<SpotResponse> GetAll([FromQuery] DateTime fromDate, DataFrequencyInterval dataFrequencyInterval)
        {
            _logger.LogInformation($"Logger works in GetAll");
            return Ok("all spots");
        }
    }
}