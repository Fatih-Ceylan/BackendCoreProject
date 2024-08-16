using FluentValidation;
using Platform.Application.Features.Commands.Definitions.GModule.Create;

namespace Platform.Application.Validators.GModule
{
    public class CreateGModuleRequestValidator : AbstractValidator<CreateGModuleRequest>
    {
        public CreateGModuleRequestValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name cannot be empty.")
                .MaximumLength(150)
                .MinimumLength(1)
                .WithMessage("Character length must be between 1 and 150.");
        }
    }
}
