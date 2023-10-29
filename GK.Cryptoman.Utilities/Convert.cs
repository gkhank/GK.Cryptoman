using System;

namespace GK.Cryptoman.Utilities
{
    public static class Convert
    {
        public static long ToUnixTimestamp(DateTime value)
        {
            DateTime unixStart = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);
            return (long)Math.Floor((value.ToUniversalTime() - unixStart).TotalMilliseconds);
        }

        public static long ToUnixTimestampWithUniversal(DateTime value)
        {
            DateTime unixStart = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);
            return (long)Math.Floor((value.ToUniversalTime() - unixStart).TotalMilliseconds);
        }
    }
}
