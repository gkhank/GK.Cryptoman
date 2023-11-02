using CryptoExchange.Net.Objects;
using GK.Cryptoman.Utilities.Shared.Exception;

namespace GK.Cryptoman.Utilities.Repositories
{
    public abstract class BaseRepository
    {
        protected static void ThrowIfNotSucessful<T>(CallResult<T> result)
        {
            if (!result.Success)
            {
                if (result is WebCallResult<T>)
                    throw new BinanceApiException((result as WebCallResult<T>).ResponseStatusCode, result.Error.Code, result.Error.Message);
                if (result is CallResult)
                    throw new BinanceWebSocketClientException(System.Net.HttpStatusCode.ServiceUnavailable, result.Error.Code, result.Error.Message);
            }

        }
    }
}
