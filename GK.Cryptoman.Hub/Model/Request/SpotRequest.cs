using GK.Cryptoman.Utilities.Shared.Model;

namespace GK.Cryptoman.Hub.Model.Request
{
    public class SpotRequest
    {
        public IEnumerable<string> Spots { get; set; }
        public DataFrequencyInterval DataFrequencyInterval { get; set; }
    }
}
