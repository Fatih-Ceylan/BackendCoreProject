using FluentValidation;
using GControl.Application.Features.Commands.Definitions.Location.Update;

namespace GControl.Application.Validators.Location
{
    public class UpdateLocationRequestValidator : AbstractValidator<UpdateLocationRequest>
    {
        public UpdateLocationRequestValidator()
        {
            RuleFor(c => c.Address)
                .NotEmpty()
                .WithMessage("Address cannot be empty.")
                .MaximumLength(150)
                .MinimumLength(1)
                .WithMessage("Character length must be between 1 and 150.");

            RuleFor(c => c.Name)
             .NotEmpty()
             .WithMessage("Name cannot be empty.")
             .MaximumLength(150)
             .MinimumLength(1)
             .WithMessage("Character length must be between 1 and 150.");

            RuleFor(c => c.Radius.ToString())
             .NotEmpty()
             .WithMessage("Radius cannot be empty.")
             .MaximumLength(150)
             .MinimumLength(1)
             .WithMessage("Character length must be between 1 and 150.");

            RuleFor(c => c.EntryTimeLimit.ToString())
             .NotEmpty()
             .WithMessage("EntryTimeLimit cannot be empty.")
             .MaximumLength(150)
             .MinimumLength(1)
             .WithMessage("Character length must be between 1 and 150.");

            RuleFor(c => c.Latitude)
             .NotEmpty()
             .WithMessage("Latitude cannot be empty.");

            RuleFor(c => c.Longitude)
             .NotEmpty()
             .WithMessage("Longitude cannot be empty.");

            RuleFor(c => c.IsEntryTimeLimitEnabled)
             .NotEmpty()
             .WithMessage("IsEntryTimeLimitEnabled cannot be empty.");

            RuleFor(c => c.LocationOut)
             .NotEmpty()
             .WithMessage("LocationOut cannot be empty.");

            RuleFor(c => c.Description)
             .NotEmpty()
             .WithMessage("Description cannot be empty.");
        }
    }
}
