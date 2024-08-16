using FluentValidation;
using GCrm.Application.Features.Commands.Definitions.CustomerType.Create;

namespace GCrm.Application.Validators.CustomerType
{
    public class CreateCustomerTypeRequestValidator : AbstractValidator<CreateCustomerTypeRequest>
    {
        public CreateCustomerTypeRequestValidator()

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
