using System.Text.Json.Serialization;

namespace GK.Cryptoman.Model.Binance
{
    public class Wallet_NetworkListResponse
    {
        [JsonPropertyName("addressRegex")]
        public string AddressRegex { get; set; }

        [JsonPropertyName("coin")]
        public string Coin { get; set; }

        [JsonPropertyName("depositDesc")]
        public string DepositDesc { get; set; }

        [JsonPropertyName("depositEnable")]
        public bool DepositEnable { get; set; }

        [JsonPropertyName("isDefault")]
        public bool IsDefault { get; set; }

        [JsonPropertyName("memoRegex")]
        public string MemoRegex { get; set; }

        [JsonPropertyName("minConfirm")]
        public int MinConfirm { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("network")]
        public string Network { get; set; }

        [JsonPropertyName("resetAddressStatus")]
        public bool ResetAddressStatus { get; set; }

        [JsonPropertyName("specialTips")]
        public string SpecialTips { get; set; }

        [JsonPropertyName("unLockConfirm")]
        public int UnLockConfirm { get; set; }

        [JsonPropertyName("withdrawDesc")]
        public string WithdrawDesc { get; set; }

        [JsonPropertyName("withdrawEnable")]
        public bool WithdrawEnable { get; set; }

        [JsonPropertyName("withdrawFee")]
        public string WithdrawFee { get; set; }

        [JsonPropertyName("withdrawMin")]
        public string WithdrawMin { get; set; }

        [JsonPropertyName("insertTime")]
        public long? InsertTime { get; set; }

        [JsonPropertyName("updateTime")]
        public long? UpdateTime { get; set; }

        [JsonPropertyName("withdrawIntegerMultiple")]
        public string WithdrawIntegerMultiple { get; set; }
    }
}
