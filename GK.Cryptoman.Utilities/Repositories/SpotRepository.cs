using Binance.Net.Interfaces.Clients;
using Binance.Net.Objects.Models.Spot;
using CryptoExchange.Net.Objects;
using GK.Cryptoman.Utilities.Shared.Exception;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace GK.Cryptoman.Utilities.Repositories
{
    public class SpotRepository : ISpotRepository
    {
        private readonly ILogger<SpotRepository> _logger;
        private readonly IBinanceRestClient _binanceRestClient;

        public SpotRepository(
            ILogger<SpotRepository> logger,
            IBinanceRestClient binanceRestClient)
        {
            _logger = logger;
            _binanceRestClient = binanceRestClient;
        }

        public async Task<BinanceAccountInfo> GetAccountInfo(CancellationToken token, bool ignoreZeroAmounts = true)
        {
            var retval = await _binanceRestClient.SpotApi.Account.GetAccountInfoAsync(ct: token);
            ThrowIfNotSucessful(retval);
            if (ignoreZeroAmounts)
                retval.Data.Balances = retval.Data.Balances.Where(x => x.Total > 0);

            return retval.Data;
        }

        private static void ThrowIfNotSucessful<T>(WebCallResult<T> webCallResult)
        {
            if (!webCallResult.Success)
                throw new BinanceApiException(webCallResult.ResponseStatusCode, webCallResult.Error.Code, webCallResult.Error.Message);
        }
    }
}
