using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace GK.Cryptoman.Utilities.Shared.Middleware.Validation
{
    public abstract class AbstractValidationHandlerMiddleware
    {
        protected readonly RequestDelegate _next;
        private readonly ILogger _logger;

        /// <summary>
        /// Gets HTTP status code response and message to be returned to the caller.
        /// </summary>
        /// <param name="validationContext">The actual httpContext to be validated</param>
        /// <returns>Tuple of HTTP status code and a message</returns>
        protected abstract (HttpStatusCode code, string message) Validate(ValidationContext<HttpContext> validationContext);

        public AbstractValidationHandlerMiddleware(ILogger logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var validationContext = new ValidationContext<HttpContext>(context);
            this.Validate(validationContext);
            await _next(context);
        }

    }
}
