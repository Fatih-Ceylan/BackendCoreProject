using FluentValidation;
using GCrm.Application.Features.Commands.Definitions.CustomerSource.Update;

namespace GCrm.Application.Validators.CustomerSource
{
    public class UpdateCustomerSourceRequestValidator : AbstractValidator<UpdateCustomerSourceRequest>
    {
        public UpdateCustomerSourceRequestValidator()
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
