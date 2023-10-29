using GK.Cryptoman.Model.Response;
using GK.Cryptoman.Utilities.Shared.Exception;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace GK.Cryptoman.Utilities.Shared.Middleware
{
    public class CustomErrorHandlerMiddleware : AbstractExceptionHandlerMiddleware
    {
        private readonly ILogger _logger;
        public CustomErrorHandlerMiddleware(ILogger<CustomErrorHandlerMiddleware> logger, RequestDelegate next) : base(logger, next)
        {
            _logger = logger;
        }

        public override (HttpStatusCode code, string message) GetResponse(System.Exception exception)
        {
            HttpStatusCode code = HttpStatusCode.Ambiguous;
            int customErrorCode = 0;
            switch (exception)
            {
                case KeyNotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                case ValidationException:
                    var validationException = exception as ValidationException;
                    code = validationException.HttpErrorCode;
                    customErrorCode = validationException.CustomErrorCode;
                    break;
                case UnauthorizedAccessException:
                    code = HttpStatusCode.Unauthorized;
                    break;
                case
                    ArgumentException
                    or InvalidOperationException:
                    code = HttpStatusCode.BadRequest;
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    break;
            }
            return (code, JsonConvert.SerializeObject(new SimplifiedExceptionResponse(exception.Message, customErrorCode)));
        }
    }
}
