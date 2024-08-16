using FluentValidation;
using GControl.Application.Features.Commands.Definitions.ShiftManagement.Create;

namespace GControl.Application.Validators.ShiftManagement
{
    public class CreateShiftManagementRequestValidator : AbstractValidator<CreateShiftManagementRequest>
    {
        public CreateShiftManagementRequestValidator()
        {
            RuleFor(c => c.Title)
               .NotEmpty()
               .WithMessage("Title cannot be empty.")
               .MaximumLength(150)
               .MinimumLength(1)
               .WithMessage("Character length must be between 1 and 150.");

            RuleFor(c => c.ShiftEndDate.ToString())
               .NotEmpty()
               .WithMessage("ShiftEndDate cannot be empty.")
               .MaximumLength(150)
               .MinimumLength(1)
               .WithMessage("Character length must be between 1 and 150.");
        }
    }
}
