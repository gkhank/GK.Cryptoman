using System.Net;

namespace GK.Cryptoman.Utilities.Shared.Exception
{
    public class ValidationException : System.Exception
    {
        public HttpStatusCode HttpErrorCode { get; private set; }
        public int CustomErrorCode { get; private set; }
        public string[] Messages { get; set; }

        public ValidationException(HttpStatusCode httpErrorCode, int customErrorCode, string[] messages, string format, params string[] args) : base(string.Format(format, args))
        {
            HttpErrorCode = httpErrorCode;
            CustomErrorCode = customErrorCode;
            Messages = messages;
        }
    }
}
