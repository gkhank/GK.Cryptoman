using Newtonsoft.Json;
using System.Security;

namespace GK.Cryptoman.Model.Binance
{
    public class BinanceApiConfiguration
    {
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public bool UseProxy { get; set; }
        public string Environment { get; set; }
        public string SpotApiKey { get; set; }
        public string SpotApiSecret { get; set; }
        public int RequestTimeoutSeconds { get; set; }
        public double ReceiveWindowSeconds { get; set; }
    }
}
