using Binance.Net.Objects.Models.Spot;
using GK.Cryptoman.Model.Response;
using GK.Cryptoman.Utilities.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GK.Cryptoman.Hub.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MarketController : BaseController
    {
        private readonly IMarketRepository _marketRepository;
        private readonly ILogger<TradeController> _logger;

        public MarketController(ILogger<TradeController> logger,
            IMarketRepository marketRepository)
        {
            _marketRepository = marketRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<BinanceSpotKline>> GetKlinesAsync([FromQuery]KlinesRequest request, CancellationToken token)
        {
            return await _marketRepository.GetKlinesAsync(request, token);
        }
    }
}
