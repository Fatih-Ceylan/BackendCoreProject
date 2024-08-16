using FluentValidation;
using Platform.Application.Features.Commands.Definitions.Company.Create;

namespace Platform.Application.Validators.Company
{
    public class CreateCompanyRequestValidator : AbstractValidator<CreateCompanyRequest>
    {
        public CreateCompanyRequestValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name cannot be empty.")
                .MaximumLength(150)
                .MinimumLength(1)
                .WithMessage("Character length must be between 1 and 150.");

            RuleFor(c => c.BaseDbName)
                .NotEmpty()
                .WithMessage("BaseDbName cannot be empty.")
                .MaximumLength(150)
                .MinimumLength(1)
                .WithMessage("Character length must be between 1 and 150.");

            RuleFor(c => c.AuthorizedFullName)
                .NotEmpty()
                .WithMessage("Authorized full name cannot be empty.")
                .MaximumLength(150)
                .MinimumLength(1)
                .WithMessage("Character length must be between 1 and 150");

            RuleFor(c => c.AdminUserFullName)
               .NotEmpty()
               .WithMessage("Admin user full name cannot be empty.")
               .MaximumLength(150)
               .MinimumLength(1)
               .WithMessage("Character length must be between 1 and 150");

            RuleFor(c => c.AdminUserEmail)
               .NotEmpty()
               .WithMessage("Admin user email cannot be empty.")
               .MaximumLength(150)
               .MinimumLength(1)
               .WithMessage("Character length must be between 1 and 150");

            RuleFor(c => c.AdminUserPassword)
               .NotEmpty()
               .WithMessage("Admin user password cannot be empty")
               .MaximumLength(150)
               .MinimumLength(3)
               .WithMessage("Character length must be between 3 and 150");

            RuleFor(c => c.AdminUserPasswordConfirm)
               .NotEmpty()
               .WithMessage("Admin user password confirm cannot be empty")
               .MaximumLength(150)
               .MinimumLength(3)
               .WithMessage("Character length must be between 3 and 150");
        }
    }
}