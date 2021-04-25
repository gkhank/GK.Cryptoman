using GK.Cryptoman.Model.Binance;
using GK.Cryptoman.Utilities;
using GK.Cryptoman.Utilities.Managers.Binance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace GK.Cryptoman.Tests
{
    [TestClass]
    public class WalletManagerTest
    {
        [TestMethod]
        public void SystemStatusWapi()
        {
            var result = Binance.Instance.Wallet.SystemStatusWapi();
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void SystemStatusSapi()
        {
            var result = Binance.Instance.Wallet.SystemStatusSapi();
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetAllCoins()
        {
            Wallet_GetAllCoinsParameters parameters = new Wallet_GetAllCoinsParameters()
            {
                TimeStamp = DateTime.Now,
                RequestValidityWindow = new TimeSpan(0, 0, 2)
            };


            var result = Binance.Instance.Wallet.GetAllCoins(parameters);
            Assert.IsNotNull(result);
        }
    }
}
