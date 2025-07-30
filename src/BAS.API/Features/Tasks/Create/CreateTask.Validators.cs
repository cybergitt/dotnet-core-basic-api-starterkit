using BAS.Application.Common.Constants;
using FluentValidation;

namespace BAS.API.Features.Tasks.Create
{
    public class CreateTaskRequestValidator : AbstractValidator<CreateTaskRequest>
    {
        public CreateTaskRequestValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                    .WithMessage(string.Format(ValidationMessages.MustBeAlphabet, "{PropertyName}"));

            RuleFor(x => x.IsComplete)
                .Must(x => x == false || x == true)
                    .WithMessage(string.Format(ValidationMessages.MustBeBoolean, "{PropertyName}"));
        }
    }
}
