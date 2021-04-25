using System;
using System.Collections.Generic;
using System.Text;

namespace GK.Cryptoman.Model.Binance
{
    public class Wallet_GetAllCoinsParameters
    {
        public TimeSpan RequestValidityWindow { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
