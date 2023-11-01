using GK.Cryptoman.Hub.Model.Response;
using GK.Cryptoman.Model.Request;
using Microsoft.AspNetCore.Mvc;

namespace GK.Cryptoman.Hub.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TradeController : BaseController
    {
        private readonly ILogger<TradeController> _logger;

        public TradeController(ILogger<TradeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<BuyResponse> Buy([FromBody]BuyResponse buyRequest)
        {
            _logger.LogInformation($"Logger works in Buy");
            return new BuyResponse();
        }

        [HttpPost]
        public async Task<SellResponse> Sell([FromBody] SellRequest buyRequest)
        {
            _logger.LogInformation($"Logger works in Sell");
            return new SellResponse();
        }
    }
}