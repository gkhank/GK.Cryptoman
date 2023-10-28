using Newtonsoft.Json;

namespace GK.Cryptoman.Model.Binance
{
    public class BinanceApiConfiguration
    {
        [JsonProperty("APIKey", NullValueHandling = NullValueHandling.Ignore)]
        public string APIKey;

        [JsonProperty("APISecret", NullValueHandling = NullValueHandling.Ignore)]
        public string APISecret;

        [JsonProperty("SpotAPIUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string SpotAPIUrl;

        [JsonProperty("SpotAPIWS", NullValueHandling = NullValueHandling.Ignore)]
        public string SpotAPIWS;

        [JsonProperty("SpotAPIStream", NullValueHandling = NullValueHandling.Ignore)]
        public string SpotAPIStream;

        [JsonProperty("UseProxy", NullValueHandling = NullValueHandling.Ignore)]
        public bool UseProxy;
    }

    public class ApplicationConfigurations
    {
        [JsonProperty("BinanceApiConfigurations", NullValueHandling = NullValueHandling.Ignore)]
        public BinanceApiConfiguration BinanceSettings;
    }
}
