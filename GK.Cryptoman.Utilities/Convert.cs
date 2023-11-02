using Binance.Net.Enums;
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
        public static KlineInterval ToKlineInterval(this string value)
        {
            if (Enum.TryParse(typeof(KlineInterval), value, true, out object result))
                return (KlineInterval)result;

            return value switch
            {
                "1s" => KlineInterval.OneSecond,
                "1m" => KlineInterval.OneMinute,
                "3m" => KlineInterval.ThreeMinutes,
                "5m" => KlineInterval.FiveMinutes,
                "15m" => KlineInterval.FifteenMinutes,
                "30m" => KlineInterval.ThirtyMinutes,
                "1h" => KlineInterval.OneHour,
                "2h" => KlineInterval.TwoHour,
                "4h" => KlineInterval.FourHour,
                "6h" => KlineInterval.SixHour,
                "8h" => KlineInterval.EightHour,
                "12h" => KlineInterval.TwelveHour,
                "1d" => KlineInterval.OneDay,
                "3d" => KlineInterval.ThreeDay,
                "1w" => KlineInterval.OneWeek,
                "1M" => KlineInterval.OneMonth,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
