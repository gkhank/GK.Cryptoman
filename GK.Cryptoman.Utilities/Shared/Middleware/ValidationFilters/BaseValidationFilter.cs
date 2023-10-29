using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace GK.Cryptoman.Utilities.Shared.Middleware.ValidationFilters
{
    public class ValidationFilter<T> : IEndpointFilter where T : class
    {
        private readonly IValidator<T> _validator;

        public ValidationFilter(IValidator<T> validator)
        {
            _validator = validator;
        }
        public async System.Threading.Tasks.ValueTask<object> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var obj = context.Arguments.FirstOrDefault(x => x?.GetType() == typeof(T)) as T;

            if (obj is null)
            {
                return Results.BadRequest();
            }

            var validationResult = await _validator.ValidateAsync(obj);

            if (!validationResult.IsValid)
            {
                return Results.BadRequest(string.Join("/n", validationResult.Errors));
            }

            return await next(context);
        }
    }
}
