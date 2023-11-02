using Binance.Net.Interfaces.Clients;
using Binance.Net.Objects.Models.Spot;
using GK.Cryptoman.Model.Response;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GK.Cryptoman.Utilities.Repositories
{
    public class MarketRepository : BaseRepository, IMarketRepository
    {
        private readonly IBinanceSocketClient _socketClient;
        private readonly ILogger<MarketRepository> _logger;

        public MarketRepository(ILogger<MarketRepository> logger, IBinanceSocketClient socketClient)
        {
            _socketClient = socketClient;
            _logger = logger;
        }

        public async Task<IEnumerable<BinanceSpotKline>> GetKlinesAsync(KlinesRequest request, CancellationToken token)
        {
            var retval = await _socketClient.SpotApi.ExchangeData.GetKlinesAsync(
                request.Symbol, 
                request.Interval.ToKlineInterval(), 
                request.FromDateUtc, 
                request.ToDateUtc);

            ThrowIfNotSucessful(retval);
            return retval.Data.Result;
        }
    }
}
