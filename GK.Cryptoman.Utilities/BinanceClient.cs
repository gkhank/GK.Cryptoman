using GK.Cryptoman.Model.Binance;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace GK.Cryptoman.Utilities
{
    public class BinanceClient : ConnectionClient
    {
        public delegate void TooManyRequestEventHandler(object sender, EventArgs e);
        public event EventHandler OnTooManyRequest;


        public delegate void OnIpBannedEventHandler(object sender, EventArgs e);
        public event EventHandler OnIpBanned;


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
#pragma warning disable CS0618 // Type or member is obsolete
                if (String.IsNullOrEmpty(this._endpointUrl))
                {
                    Random rnd = new Random();
                    this._endpointUrl = this._endpointUrls[rnd.Next(0, this._endpointUrls.Length)];
                }

                return this._endpointUrl;
            }
            private set { this._endpointUrl = value; }
#pragma warning restore CS0618 // Type or member is obsolete
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
            HttpWebRequest exceededRequest = sender as HttpWebRequest; 
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

        public T Get<T>(string url, bool useProxy)
        {
            try
            {
                if (url.StartsWith(this.EndpointUrl) == false)
                    url = this.EndpointUrl + url;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;
                request.Timeout = 10000;
                request.Method = "GET";
                request.Headers.Add("X-MBX-APIKEY", Configuration.Instance.Connections.BinanceAPI.APIKey);
                return this.DoRequest<T>(request, null, useProxy);
            }
            catch (WebException wex)
            {
                HttpWebResponse webResponse = wex.Response as HttpWebResponse;

                if (webResponse == null)
                    throw wex;

                GenericResponse exceptionResponse = null;
                using (Stream stream = webResponse.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    String serverExceptionResponse = reader.ReadToEnd();
                    exceptionResponse = JsonConvert.DeserializeObject<GenericResponse>(serverExceptionResponse);
                }

                Int32 statusCode = (Int32)webResponse.StatusCode;
                switch (statusCode)
                {
                    case 429:
                        if (this.OnTooManyRequest != null)
                            this.OnTooManyRequest.Invoke(wex, EventArgs.Empty);
                        break;
                    case 418:
                        if (this.OnIpBanned != null)
                            this.OnIpBanned.Invoke(wex, EventArgs.Empty);
                        break;
                    case 403:
                        EventLog.WriteEntry(this.ToString(), "WAF Limit (Web Application Firewall) has been violated.", EventLogEntryType.Error, statusCode);
                        break;
                    default:

                        if (statusCode >= 400 && statusCode < 500)
                        {
                            EventLog.WriteEntry(this.ToString(), "Malformed requests; the issue is on the sender's side", EventLogEntryType.Error, statusCode);
                        }
                        else if (statusCode >= 500 && statusCode < 600)
                        {
                            EventLog.WriteEntry(this.ToString(), "Internal errors; the issue is on Binance's side.", EventLogEntryType.Error, statusCode);
                        }
                        break;
                }

                if (exceptionResponse != null)
                    EventLog.WriteEntry(this.ToString(), exceptionResponse.Msg, EventLogEntryType.Error, exceptionResponse.Code * -1);


                throw wex;
            }
        }

        public T Post<T>(string url, Object data, bool useProxy)
        {
            try
            {
                if (url.StartsWith(this.EndpointUrl) == false)
                    url = this.EndpointUrl + url;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;
                request.Timeout = 10000;
                request.Method = "POST";
                request.Headers.Add("X-MBX-APIKEY", Configuration.Instance.Connections.BinanceAPI.APIKey);

                return this.DoRequest<T>(request, data, useProxy);
            }
            catch (WebException wex)
            {
                HttpWebResponse webResponse = wex.Response as HttpWebResponse;

                if (webResponse == null)
                    throw wex;

                GenericResponse exceptionResponse = null;
                using (Stream stream = webResponse.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    String serverExceptionResponse = reader.ReadToEnd();
                    exceptionResponse = JsonConvert.DeserializeObject<GenericResponse>(serverExceptionResponse);
                }

                Int32 statusCode = (Int32)webResponse.StatusCode;
                switch (statusCode)
                {
                    case 429:
                        if (this.OnTooManyRequest != null)
                            this.OnTooManyRequest.Invoke(wex, EventArgs.Empty);
                        break;
                    case 418:
                        if (this.OnIpBanned != null)
                            this.OnIpBanned.Invoke(wex, EventArgs.Empty);
                        break;
                    case 403:
                        EventLog.WriteEntry(this.ToString(), "WAF Limit (Web Application Firewall) has been violated.", EventLogEntryType.Error, statusCode);
                        break;
                    default:

                        if (statusCode >= 400 && statusCode < 500)
                        {
                            EventLog.WriteEntry(this.ToString(), "Malformed requests; the issue is on the sender's side", EventLogEntryType.Error, statusCode);
                        }
                        else if (statusCode >= 500 && statusCode < 600)
                        {
                            EventLog.WriteEntry(this.ToString(), "Internal errors; the issue is on Binance's side.", EventLogEntryType.Error, statusCode);
                        }
                        break;
                }

                if (exceptionResponse != null)
                    EventLog.WriteEntry(this.ToString(), exceptionResponse.Msg, EventLogEntryType.Error, exceptionResponse.Code * -1);


                throw wex;
            }
        }
    }
}
