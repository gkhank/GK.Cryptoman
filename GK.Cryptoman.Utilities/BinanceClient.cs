using System;
using System.Net;

namespace GK.Cryptoman.Utilities
{
    public class BinanceClient : ConnectionClient
    {

        private readonly String[] _endpointUrls = new String[] {
            "https://api1.binance.com",
            "https://api2.binance.com",
            "https://api3.binance.com"
        };

        [Obsolete("Use property accessor")]
        private string _endpointUrl;
        public String EndpointUrl
        {
            get
            {
                if (String.IsNullOrEmpty(this._endpointUrl))
                {
                    Random rnd = new Random();
                    this._endpointUrl = this._endpointUrls[rnd.Next(0, this._endpointUrls.Length)];
                }

                return this._endpointUrl;
            }
            private set { this._endpointUrl = value; }
        }

        public BinanceClient(String endpoint) : this()
        {
            if (String.IsNullOrEmpty(endpoint) == false)
                this.EndpointUrl = endpoint;
        }

        public BinanceClient()
        {
            this.OnExecutionTimeLimitExceeded += BinanceClient_OnExecutionTimeLimitExceeded;
        }

        private void BinanceClient_OnExecutionTimeLimitExceeded(object sender, EventArgs e)
        {
            WebRequest exceededRequest = sender as WebRequest;

            this.EndpointUrl = this.ChangeEndpointUrl(exceededRequest.RequestUri.Host);
        }

        private string ChangeEndpointUrl(string avoid = null)
        {
            for (int i = 0; i < this._endpointUrls.Length; i++)
            {
                if (this._endpointUrls[i].StartsWith(avoid) == false)
                    return this._endpointUrls[i];
            }

            throw new Exception($"Could not determine an endpoint url to use for {this}");
        }

        public override T Get<T>(string url, bool useProxy = true)
        {
            url = this.EndpointUrl + url;
            return base.Get<T>(url, useProxy);
        }
    }
}
