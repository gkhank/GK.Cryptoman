using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GK.Cryptoman.Utilities.Shared.Middleware
{
    /// <summary>
    /// Abstract handler for all exceptions.
    /// </summary>
    public abstract class AbstractExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        /// <summary>
        /// Gets HTTP status code response and message to be returned to the caller.
        /// Use the ".Data" property to set the key of the messages if it's localized.
        /// </summary>
        /// <param name="exception">The actual exception</param>
        /// <returns>Tuple of HTTP status code and a message</returns>
        public abstract (HttpStatusCode code, string message) GetResponse(System.Exception exception);

        public AbstractExceptionHandlerMiddleware(ILogger logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception exception)
            {
                // log the error
                _logger.LogError(exception, "error during executing {Context}", context.Request.Path.Value);
                var response = context.Response;
                response.ContentType = "application/json";

                // get the response code and message
                var (status, message) = GetResponse(exception);
                response.StatusCode = (int)status;
                await response.WriteAsync(message);
            }
        }
    }
}
