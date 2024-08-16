using FluentValidation;
using GCrm.Application.Features.Commands.Definitions.CustomerKind.Update;

namespace GCrm.Application.Validators.CustomerKind
{
    public class UpdateCustomerKindRequestValidator : AbstractValidator<UpdateCustomerKindRequest>
    {
        public UpdateCustomerKindRequestValidator()
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
