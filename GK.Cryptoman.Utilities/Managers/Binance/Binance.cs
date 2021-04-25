using System;
using System.Collections.Generic;
using System.Text;

namespace GK.Cryptoman.Utilities.Managers.Binance
{
    public class Binance
    {
        protected static Binance _instance;

        #region Singleton
        public static Binance Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Binance();
                }

                return _instance;
            }
        }

        #endregion
        public WalletManager Wallet = new WalletManager();
    }
}
