using FluentValidation;
using GCrm.Application.Features.Commands.Definitions.CustomerStatus.Create;

namespace GCrm.Application.Validators.CustomerStatus
{
    public class CreateCustomerStatusRequestValidator : AbstractValidator<CreateCustomerStatusRequest>
    {
        public CreateCustomerStatusRequestValidator()
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
