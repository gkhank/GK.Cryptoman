using FluentValidation;
using GK.Cryptoman.Model.Request;

namespace GK.Cryptoman.Hub.Validators
{
    public class SpotRequestValidator: AbstractValidator<SpotRequest> , IValidator<SpotRequest>
    {
        public SpotRequestValidator()
        {
            RuleFor(s => s.Spots)
                .NotNull();

            RuleForEach(s => s.Spots)
                .NotNull()
                .NotEmpty()
                .Length(20);
        }
    }
}
