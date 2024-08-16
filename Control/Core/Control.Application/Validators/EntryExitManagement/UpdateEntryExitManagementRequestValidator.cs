using FluentValidation;
using GControl.Application.Features.Commands.Definitions.EntryExitManagement.Update;

namespace GControl.Application.Validators.EntryExitManagement
{
    public class UpdateEntryExitManagementRequestValidator : AbstractValidator<UpdateEntryExitManagementRequest>
    {
        public UpdateEntryExitManagementRequestValidator()
        {
            RuleFor(c => c.EmployeeId)
                .NotEmpty()
                .WithMessage("EmployeeId cannot be empty.")
                .MaximumLength(150)
                .MinimumLength(1)
                .WithMessage("Character length must be between 1 and 150.");

            RuleFor(c => c.LocationId)
             .NotEmpty()
             .WithMessage("LocationId cannot be empty.");

            RuleFor(c => c.DateTime.ToString())
             .NotEmpty()
             .WithMessage("DateTime cannot be empty.")
             .MaximumLength(150)
             .MinimumLength(1)
             .WithMessage("Character length must be between 1 and 150.");

            RuleFor(c => c.IsLocationOut.ToString())
             .NotEmpty()
             .WithMessage("EntryTimeLimit cannot be empty.")
             .MaximumLength(150)
             .MinimumLength(1)
             .WithMessage("Character length must be between 1 and 150.");
        }
    }
}
