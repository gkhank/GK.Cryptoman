using Binance.Net.Objects.Models.Spot;
using GK.Cryptoman.Model.Request;
using System.Threading;
using System.Threading.Tasks;

namespace GK.Cryptoman.Utilities.Repositories
{
    public interface IAccountRepository
    {
        Task<BinanceAccountInfo> GetAccountInfo(CancellationToken token, bool ignoreZeroAmounts = true);
    }
}