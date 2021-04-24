using GK.Cryptoman.Model.Binance;
using GK.Cryptoman.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace GK.Cryptoman.Tests
{
    [TestClass]
    public class BinanceAPITests
    {
        [TestMethod]
        public void ConnectionTest()
        {
            String signature =
                HMAC_SHA256.GetHash(Configuration.Instance.Connections.BinanceAPI.APIKey, Configuration.Instance.Connections.BinanceAPI.APISecret);

            BinanceClient client = new BinanceClient();

            String url = String.Format("{0}?signature={1}",
                "/wapi/v3/systemStatus.html",
                signature);

            SystemStatusResponse result = client.Get<SystemStatusResponse>(url, false);
        }
    }
}
