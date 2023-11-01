using System.Collections.Generic;

namespace GK.Cryptoman.Model.Request
{
    public class SpotRequest
    {
        public IEnumerable<string> Spots { get; set; }
        public DataFrequencyInterval DataFrequencyInterval { get; set; }
    }
}
