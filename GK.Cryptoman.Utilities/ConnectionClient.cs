using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace GK.Cryptoman.Utilities
{
    public class ConnectionClient
    {
        public virtual TimeSpan ExecutionTimeLimit { get; protected set; }

        public ConnectionClient()
        {
            this.ExecutionTimeLimit = new TimeSpan(0, 0, 5);
            this.OnExecutionTimeLimitExceeded += ConnectionClient_OnExecutionTimeLimitExceeded;
        }

        private void ConnectionClient_OnExecutionTimeLimitExceeded(object sender, EventArgs e)
        {
            //Force proxy to be reloaded on long requests.
            this._proxy = null;
        }

        private WebProxy _proxy;

        private WebProxy Proxy
        {
            get
            {
                if (this._proxy == null)
                    this._proxy = SelectProxy();
                return this._proxy;
            }
        }

        public delegate void ExecutionTimeLimitExceededEventHandler(object sender, EventArgs e);
        public event EventHandler OnExecutionTimeLimitExceeded;

        private WebProxy SelectProxy()
        {

            String[] hosts = File.ReadAllLines(Path.Combine(ApplicationPath.ConfigDirectory, "proxy.txt"));

            //https://openproxy.space/list/ZTABrk0Fn3
            Random rnd = new Random();
            string host = hosts[rnd.Next(0, hosts.Length - 1)];
            String[] pieces = host.Split(':');

            EventLog.WriteEntry(this.ToString(), String.Format("Selected proxy server '{0}'.", host), EventLogEntryType.Information);

            WebProxy retval = new WebProxy(pieces[0], Int32.Parse(pieces[1]));

            if (pieces.Length > 2)
            {
                NetworkCredential credentials = new NetworkCredential(
                    pieces[2],
                    pieces[3]
                );

                retval.Credentials = credentials;
            }


            return retval;
        }

        protected T DoRequest<T>(HttpWebRequest request, object data, Boolean useProxy)
        {

            if (useProxy)
            {
                request.Proxy = this.Proxy;

                CallResult result = this.DoCall(request, data);

                //If call took more than 5 seconds force re-load proxy.
                if (result.ProcessSpan > this.ExecutionTimeLimit && this.OnExecutionTimeLimitExceeded != null)
                {
                    this.OnExecutionTimeLimitExceeded.Invoke(request, EventArgs.Empty);
                }

                return JsonConvert.DeserializeObject<T>(result.Content);
            }
            else
                return JsonConvert.DeserializeObject<T>(this.DoCall(request, data).Content);

        }

        private CallResult DoCall(HttpWebRequest request, Object data)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                if (request.Method == "POST")
                {
                    using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        string json = JsonConvert.SerializeObject(data);
                        streamWriter.Write(json);
                        streamWriter.Flush();
                    }
                }

                String content = reader.ReadToEnd();
                watch.Stop();
                return new CallResult(content, watch.Elapsed);
            }
        }

        protected class CallResult
        {
            public String Content { get; set; }
            public TimeSpan ProcessSpan { get; set; }

            public CallResult(String content, TimeSpan processSpan)
            {
                this.Content = content;
                this.ProcessSpan = processSpan;
            }
        }
    }
}


