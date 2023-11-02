using Binance.Net.Objects.Models.Spot;
using GK.Cryptoman.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace GK.Cryptoman.Utilities.Repositories
{
    public interface IMarketRepository
    {
        Task<IEnumerable<BinanceSpotKline>> GetKlinesAsync(KlinesRequest request, CancellationToken token);
    }
}