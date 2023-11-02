using Binance.Net.Interfaces.Clients;
using Binance.Net.Objects.Models.Spot;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace GK.Cryptoman.Utilities.Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        private readonly ILogger<AccountRepository> _logger;
        private readonly IBinanceRestClient _binanceRestClient;

        public AccountRepository(
            ILogger<AccountRepository> logger,
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
    }
}
