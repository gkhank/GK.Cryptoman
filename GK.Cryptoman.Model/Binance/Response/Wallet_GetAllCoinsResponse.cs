using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GK.Cryptoman.Model.Binance
{
    public class Wallet_GetAllCoinsResponse
    {
        [JsonPropertyName("coin")]
        public string Coin { get; set; }

        [JsonPropertyName("depositAllEnable")]
        public bool DepositAllEnable { get; set; }

        [JsonPropertyName("free")]
        public string Free { get; set; }

        [JsonPropertyName("freeze")]
        public string Freeze { get; set; }

        [JsonPropertyName("ipoable")]
        public string Ipoable { get; set; }

        [JsonPropertyName("ipoing")]
        public string Ipoing { get; set; }

        [JsonPropertyName("isLegalMoney")]
        public bool IsLegalMoney { get; set; }

        [JsonPropertyName("locked")]
        public string Locked { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("networkList")]
        public List<Wallet_NetworkListResponse> NetworkList { get; set; }

        [JsonPropertyName("storage")]
        public string Storage { get; set; }

        [JsonPropertyName("trading")]
        public bool Trading { get; set; }

        [JsonPropertyName("withdrawAllEnable")]
        public bool WithdrawAllEnable { get; set; }

        [JsonPropertyName("withdrawing")]
        public string Withdrawing { get; set; }
    }


}
