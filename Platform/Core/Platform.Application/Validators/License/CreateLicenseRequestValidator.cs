using FluentValidation;
using Platform.Application.Features.Commands.Definitions.License.Create;

namespace Platform.Application.Validators.License
{
    public class CreateLicenseRequestValidator : AbstractValidator<CreateLicenseRequest>
    {
        public CreateLicenseRequestValidator()
        {
            RuleFor(c => c.CompanyId)
                .NotEmpty()
                .WithMessage("Company cannot be empty.");

            RuleFor(c => c.GModuleId)
                .NotEmpty()
                .WithMessage("GModule cannot be empty.");

            RuleFor(c => c.LicenseTypeId)
               .NotEmpty()
               .WithMessage("LicenseType name cannot be empty.");

            RuleFor(c => c.StartDate)
              .NotEmpty()
              .WithMessage("StartDate cannot be empty.");
         
        }
    }
}
