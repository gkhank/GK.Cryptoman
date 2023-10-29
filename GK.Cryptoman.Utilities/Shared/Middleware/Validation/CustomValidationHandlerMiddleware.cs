using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace GK.Cryptoman.Utilities.Shared.Middleware.Validation
{
    public class CustomValidationHandlerMiddleware : AbstractValidationHandlerMiddleware
    {
        private readonly ILogger _logger;
        private readonly IEnumerable<IValidator> _validators;

        public CustomValidationHandlerMiddleware(IEnumerable<IValidator> validators, ILogger<CustomValidationHandlerMiddleware> logger, RequestDelegate next) : base(logger, next)
        {
            _logger = logger;
            _validators = validators;
        }
        protected override (HttpStatusCode code, string message) Validate(ValidationContext<HttpContext> validationContext)
        {

            var errorMessages = _validators.Select(x => x.Validate(validationContext)).SelectMany(x => x.Errors);
            if (errorMessages.Any())
            {
                throw new GK.Cryptoman.Utilities.Shared.Exception.ValidationException(
                    HttpStatusCode.BadRequest,
                    10002,
                    errorMessages.Select(error => error.ErrorMessage).ToArray(),
                    "Request validation errors occured. See error messages.");
            }

            return (HttpStatusCode.OK, "All validators are OK!");
        }
    }
}
