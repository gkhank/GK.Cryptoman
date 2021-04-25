using Newtonsoft.Json;
using System;
using System.IO;

namespace GK.Cryptoman.Utilities
{

    public class Configuration
    {
        public Boolean IsDevelopment { get { return Environment.MachineName != "GK-WS1"; } }

        public Connections Connections { get; set; }


        #region Singleton

        protected static Configuration _instance;

        public static Configuration Instance
        {
            get
            {
                if (_instance == null)
                {
                    String file = Path.Combine(ApplicationPath.ConfigDirectory, "config.json");
                    _instance = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(file));
                }

                return _instance;
            }
        }

        #endregion


    }
    #region Config Models
    public class BinanceConfig
    {
        public string APIKey { get; set; }
        public string APISecret { get; set; }
        public string SpotAPIUrl { get; set; }
        public string SpotAPIWS { get; set; }
        public string SpotAPIStream { get; set; }
        public bool UseProxy{ get; set; }
    }

    public class Connections
    {
        public BinanceConfig BinanceAPI { get; set; }
    }
    #endregion
}
