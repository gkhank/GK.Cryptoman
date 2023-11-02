using System;

namespace GK.Cryptoman.Model.Response
{
    public class KlinesRequest
    {
        public string Symbol { get; set; }
        public DateTime FromDateUtc{ get; set; }
        public DateTime? ToDateUtc { get; set; }
        public string Interval{ get; set; }
    }
}
