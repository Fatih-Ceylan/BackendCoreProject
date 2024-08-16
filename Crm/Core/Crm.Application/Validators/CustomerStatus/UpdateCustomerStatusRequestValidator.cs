using FluentValidation;
using GCrm.Application.Features.Commands.Definitions.CustomerStatus.Update;

namespace GCrm.Application.Validators.CustomerStatus
{
    public class UpdateCustomerStatusRequestValidator : AbstractValidator<UpdateCustomerStatusRequest>
    {

        public UpdateCustomerStatusRequestValidator()
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
