using System.Text.Json.Serialization;

namespace GK.Cryptoman.Model.Binance
{
    public class GenericResponse
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("msg")]
        public string Msg { get; set; }
    }


}
