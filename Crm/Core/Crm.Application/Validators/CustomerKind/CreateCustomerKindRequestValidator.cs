using FluentValidation;
using GCrm.Application.Features.Commands.Definitions.CustomerKind.Create;

namespace GCrm.Application.Validators.CustomerKind
{
    public class CreateCustomerKindRequestValidator : AbstractValidator<CreateCustomerKindRequest>
    {

        public CreateCustomerKindRequestValidator()
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
