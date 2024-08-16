using FluentValidation;
using GCrm.Application.Features.Commands.Definitions.CustomerType.Update;

namespace GCrm.Application.Validators.CustomerType
{
    public class UpdateCustomerTypeRequestValidator : AbstractValidator<UpdateCustomerTypeRequest>
    {
        public UpdateCustomerTypeRequestValidator()

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
