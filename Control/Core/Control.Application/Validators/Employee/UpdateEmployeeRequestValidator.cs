using FluentValidation;
using GControl.Application.Features.Commands.Definitions.Employee.Update;

namespace GControl.Application.Validators.Employee
{
    public class UpdateEmployeeRequestValidator : AbstractValidator<UpdateEmployeeRequest>
    {
        public UpdateEmployeeRequestValidator()
        {
            RuleFor(c => c.ProfilePicturePath)
                .NotEmpty()
                .WithMessage("ProfilePicture cannot be empty.");

            RuleFor(c => c.RegistrationNumber)
             .NotEmpty()
             .WithMessage("RegistrationNumber cannot be empty.")
             .MaximumLength(150)
             .MinimumLength(1)
             .WithMessage("Character length must be between 1 and 150.");

            RuleFor(c => c.StartWorkDate.ToString())
             .NotEmpty()
             .WithMessage("StartWorkDate cannot be empty.")
             .MaximumLength(150)
             .MinimumLength(1)
             .WithMessage("Character length must be between 1 and 150.");

            RuleFor(c => c.FullName)
             .NotEmpty()
             .WithMessage("FullName cannot be empty.")
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

            RuleFor(c => c.isActive.ToString())
            .NotEmpty()
            .WithMessage("isActive cannot be empty.")
            .MaximumLength(150)
            .MinimumLength(1)
            .WithMessage("Character length must be between 1 and 150.");

            RuleFor(c => c.DepartmentId.ToString())
            .NotEmpty()
            .WithMessage("DepartmentId cannot be empty.");
        }
    }
}
