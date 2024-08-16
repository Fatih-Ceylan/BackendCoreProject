using FluentValidation;
using GCrm.Application.Features.Commands.Definitions.CustomerContact.Update;

namespace GCrm.Application.Validators.CustomerContact
{
    public class UpdateCustomerContactRequestValidator : AbstractValidator<UpdateCustomerContactRequest>
    {
        public UpdateCustomerContactRequestValidator()
        {
            RuleFor(c => c.Name)
             //.NotEmpty()
             //.WithMessage("Name cannot be empty.")
             .MaximumLength(150)
             .MinimumLength(1)
             .WithMessage("Character length must be between 1 and 150.");

            RuleFor(c => c.CustomerId)
             //.NotEmpty()
             //.WithMessage("CustomerId cannot be empty.")
             .MaximumLength(150)
             .MinimumLength(1)
             .WithMessage("Character length must be between 1 and 150.");

            //RuleFor(c => c.Title)
            // .NotEmpty()
            // .WithMessage("Title cannot be empty.")
            // .MaximumLength(150)
            // .MinimumLength(1)
            // .WithMessage("Character length must be between 1 and 150.");

            RuleFor(c => c.Department)
             //.NotEmpty()
             //.WithMessage("Department cannot be empty.")
             .MaximumLength(150)
             .MinimumLength(1)
             .WithMessage("Character length must be between 1 and 150.");

            RuleFor(c => c.Mobile)
             //.NotEmpty()
             //.WithMessage("Mobile cannot be empty.")
             .MaximumLength(150)
             .MinimumLength(1)
             .WithMessage("Character length must be between 1 and 150.");

            RuleFor(c => c.Email1)
            //.NotEmpty()
            //.WithMessage("Email1 cannot be empty.")
            .MaximumLength(150)
            .MinimumLength(1)
            .WithMessage("Character length must be between 1 and 150.");
        }
    }
}
