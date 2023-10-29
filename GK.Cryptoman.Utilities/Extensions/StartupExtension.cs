using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GK.Cryptoman.Utilities.Extensions
{
    public static class StartupExtension
    {
        public static void RegisterBinanceHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<Binance.Net.Clients.GeneralApi.BinanceRestClientGeneralApi>();
            services.AddHttpClient<Binance.Net.Clients.GeneralApi.BinanceRestClientGeneralApiMining>();
            services.AddHttpClient<Binance.Net.Clients.SpotApi.BinanceRestClientSpotApi>();
            services.AddHttpClient<Binance.Net.Clients.SpotApi.BinanceSocketClientSpotApiTrading>();
            services.AddHttpClient<Binance.Net.Clients.SpotApi.BinanceSocketClientSpotApiExchangeData>();
            services.AddHttpClient<Binance.Net.Clients.SpotApi.BinanceSocketClientSpotApiAccount>();
        }
    }
}
