using FluentValidation;

namespace BAS.API.Features.Tasks.Create
{
    public class CreateTaskRequestValidator : AbstractValidator<CreateTaskRequest>
    {
        public CreateTaskRequestValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.IsComplete).NotEmpty();
        }
    }
}
