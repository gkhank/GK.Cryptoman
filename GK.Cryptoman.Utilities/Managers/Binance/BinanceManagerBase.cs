using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GK.Cryptoman.Utilities.Managers
{
    public abstract class BinanceManagerBase
    {

        protected readonly string _signature;
        protected readonly BinanceClient _client;
        private static BinanceManagerBase _instance;


        public BinanceManagerBase()
        {
            this._signature = HashHandler.GetHash(Configuration.Instance.Connections.BinanceAPI.APIKey,
                                                  Configuration.Instance.Connections.BinanceAPI.APISecret);
            this._client = new BinanceClient();
        }

    }
}
