using FluentValidation;
using GCrm.Application.Features.Commands.Definitions.CustomerSource.Create;

namespace GCrm.Application.Validators.CustomerSource
{
    public class CreateCustomerSourceRequestValidator : AbstractValidator<CreateCustomerSourceRequest>
    {

        public CreateCustomerSourceRequestValidator()
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
