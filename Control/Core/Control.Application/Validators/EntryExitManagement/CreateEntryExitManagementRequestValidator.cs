using FluentValidation;
using GControl.Application.Features.Commands.Definitions.EntryExitManagement.Create;

namespace GControl.Application.Validators.EntryExitManagement
{
    public class CreateEntryExitManagementRequestValidator : AbstractValidator<CreateEntryExitManagementRequest>
    {
        public CreateEntryExitManagementRequestValidator()
        {
            RuleFor(c => c.EmployeeId.ToString())
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

            //RuleFor(c => c.IsLocationOut.ToString())
            // .NotEmpty()
            // .WithMessage("EntryTimeLimit cannot be empty.")
            // .MaximumLength(150)
            // .MinimumLength(1)
            // .WithMessage("Character length must be between 1 and 150.");

        }
    }
}
