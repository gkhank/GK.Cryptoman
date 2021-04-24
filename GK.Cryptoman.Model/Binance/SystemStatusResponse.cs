using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GK.Cryptoman.Model.Binance
{
    public class SystemStatusResponse
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }
    }
}
