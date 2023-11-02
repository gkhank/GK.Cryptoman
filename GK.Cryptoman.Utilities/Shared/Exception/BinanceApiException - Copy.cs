using System;
using System.Net;

namespace GK.Cryptoman.Utilities.Shared.Exception
{
    public class BinanceWebSocketClientException : System.Exception
    {
        public HttpStatusCode HttpErrorCode { get; private set; }
        public int CustomErrorCode { get; private set; }
        public string[] Messages { get; set; }

        public BinanceWebSocketClientException(HttpStatusCode? httpErrorCode, int? customErrorCode, string format, params string[] args) : base(TryParseMessage(format, args))
        {
            HttpErrorCode = httpErrorCode.HasValue ? httpErrorCode.Value : HttpStatusCode.NotAcceptable;
            CustomErrorCode = customErrorCode.HasValue ? customErrorCode.Value : -1;
            Messages = new string[] { format };
        }

        private static string TryParseMessage(string format, string[] args)
        {
            try
            {
                return string.Format(format, args);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Error message from client could not be parsed into an understandable message.");
                return format;
            }
        }
    }
}
