using FluentValidation;
using GCrm.Application.Features.Commands.Definitions.CustomerSector.Update;

namespace GCrm.Application.Validators.CustomerSector
{
    public class UpdateCustomerSectorRequestValidator : AbstractValidator<UpdateCustomerSectorRequest>
    {

        public UpdateCustomerSectorRequestValidator()

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
