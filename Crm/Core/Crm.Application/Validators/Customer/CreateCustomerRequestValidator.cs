using FluentValidation;
using GCrm.Application.Features.Commands.Definitions.Customer.Create;

namespace GCrm.Application.Validators.Customer
{
    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {

        public CreateCustomerRequestValidator()
        {

            //RuleFor(c => c.Code)
            //    .NotEmpty()
            //    .WithMessage("Code cannot be empty.")
            //    .MaximumLength(150)
            //    .MinimumLength(1)
            //    .WithMessage("Character length must be between 1 and 150.");

            ////RuleFor(c => c.Group)
            //// .NotEmpty()
            //// .WithMessage("Group cannot be empty.")
            //// .MaximumLength(150)
            //// .MinimumLength(1)
            //// .WithMessage("Character length must be between 1 and 150.");

            //RuleFor(c => c.Name)
            // .NotEmpty()
            // .WithMessage("Name cannot be empty.")
            // .MaximumLength(150)
            // .MinimumLength(1)
            // .WithMessage("Character length must be between 1 and 150.");

            //RuleFor(c => c.CustomerStatusId)
            // .NotEmpty()
            // .WithMessage("CustomerStatusId cannot be empty.")
            // .MaximumLength(150)
            // .MinimumLength(1)
            // .WithMessage("Character length must be between 1 and 150.");

            //RuleFor(c => c.CustomerSectorId)
            // .NotEmpty()
            // .WithMessage("CustomerSectorId cannot be empty.")
            // .MaximumLength(150)
            // .MinimumLength(1)
            // .WithMessage("Character length must be between 1 and 150.");

            //RuleFor(c => c.CustomerSourceId)
            // .NotEmpty()
            // .WithMessage("CustomerSourceId cannot be empty.")
            // .MaximumLength(150)
            // .MinimumLength(1)
            // .WithMessage("Character length must be between 1 and 150.");

            ////RuleFor(c => c.CustomerRepresentative)
            //// .NotEmpty()
            //// .WithMessage("CustomerRepresentative cannot be empty.")
            //// .MaximumLength(150)
            //// .MinimumLength(1)
            //// .WithMessage("Character length must be between 1 and 150.");



        }
    }
}
