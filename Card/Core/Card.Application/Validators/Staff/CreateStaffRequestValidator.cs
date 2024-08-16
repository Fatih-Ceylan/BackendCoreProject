using FluentValidation;
using Card.Application.Features.Commands.Definitions.Staff.Create;

namespace Card.Application.Validators.Staff
{
    public class CreateStaffRequestValidator : AbstractValidator<CreateStaffRequest>
    {
        public CreateStaffRequestValidator()
        {
            RuleFor(c => c.Name)
               .NotEmpty()
               .WithMessage("Name cannot be empty.")
               .MaximumLength(150)
               .MinimumLength(1)
               .WithMessage("Character length must be between 1 and 150.");

            RuleFor(c => c.LastName)
               .NotEmpty()
               .WithMessage("LastName cannot be empty.")
               .MaximumLength(150)
               .MinimumLength(1)
               .WithMessage("Character length must be between 1 and 150.");

            RuleFor(c => c.UserName)
               .NotEmpty()
               .WithMessage("UserName cannot be empty.")
               .MaximumLength(150)
               .MinimumLength(1)
               .WithMessage("Character length must be between 1 and 150.");

            RuleFor(c => c.Title)
               .NotEmpty()
               .WithMessage("Title cannot be empty.")
               .MaximumLength(150)
               .MinimumLength(1)
               .WithMessage("Character length must be between 1 and 150.");

            RuleFor(c => c.Email)
               .NotEmpty()
               .WithMessage("Email cannot be empty.")
               .MaximumLength(150)
               .MinimumLength(1)
               .WithMessage("Character length must be between 1 and 150.");

            RuleFor(c => c.PhoneNumber)
               .NotEmpty()
               .WithMessage("PhoneNumber cannot be empty.")
               .MaximumLength(150)
               .MinimumLength(1)
               .WithMessage("Character length must be between 1 and 150.");

            RuleFor(c => c.Password)
               .NotEmpty()
               .WithMessage("PhoneNumber cannot be empty.")
               .MaximumLength(150)
               .MinimumLength(1)
               .WithMessage("Character length must be between 1 and 150.");
        }
    }
}
