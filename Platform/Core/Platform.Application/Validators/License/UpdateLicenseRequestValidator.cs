using FluentValidation;
using Platform.Application.Features.Commands.Definitions.License.Update;

namespace Platform.Application.Validators.License
{
    public class UpdateLicenseRequestValidator : AbstractValidator<UpdateLicenseRequest>
    {
        public UpdateLicenseRequestValidator()
        {
            
            RuleFor(c => c.StartDate)
              .NotEmpty()
              .WithMessage("StartDate cannot be empty.");

        }
    }
}