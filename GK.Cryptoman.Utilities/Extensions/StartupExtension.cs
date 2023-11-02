using Binance.Net;
using CryptoExchange.Net.Authentication;
using FluentValidation;
using GK.Cryptoman.Model.Binance;
using GK.Cryptoman.Utilities.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace GK.Cryptoman.Utilities.Extensions
{
    public static class StartupExtension
    {
        public static void RegisterBinanceHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            var binanceConfig = configuration.GetRequiredSection("ApplicationSettings:Binance").Get<BinanceApiConfiguration>();
            services.AddBinance(
                restOptions =>
                {
                    restOptions.Environment = GetBinanceEnvironment(binanceConfig.Environment);
                    restOptions.ApiCredentials = new ApiCredentials(binanceConfig.ApiKey, binanceConfig.ApiSecret, ApiCredentialsType.Hmac);
                    //restOptions.SpotOptions.ApiCredentials = new ApiCredentials(binanceConfig.SpotApiKey, binanceConfig.SpotApiSecret);
                    restOptions.ReceiveWindow = TimeSpan.FromSeconds(binanceConfig.ReceiveWindowSeconds);
                    restOptions.RequestTimeout = TimeSpan.FromSeconds(binanceConfig.RequestTimeoutSeconds);
                },
                socketClientOptions =>
                {
                    socketClientOptions.Environment = GetBinanceEnvironment(binanceConfig.Environment);
                    socketClientOptions.AutoReconnect = true;
                    socketClientOptions.ApiCredentials = new ApiCredentials(binanceConfig.ApiKey, binanceConfig.ApiSecret, ApiCredentialsType.Hmac);
                });
        }

        public static BinanceEnvironment GetBinanceEnvironment(string environment) => environment.ToLower() switch
        {
            "live" => BinanceEnvironment.Live,
            "us" => BinanceEnvironment.Us,
            "testnet" or "test" => BinanceEnvironment.Testnet,
            _ => throw new ArgumentOutOfRangeException(nameof(environment), $"Not expected BinanceEnvironment value: {environment}"),
        };

        public static void RegisterValidators(this IServiceCollection services, Assembly assembly)
        {
            services.AddValidatorsFromAssembly(assembly);
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IMarketRepository, MarketRepository>();
        }
    }
}
