using FluentValidation;
using GCrm.Application.Features.Commands.Definitions.CustomerCategory.Create;

namespace GCrm.Application.Validators.CustomerCategory
{
    public class CreateCustomerCategoryRequestValidator : AbstractValidator<CreateCustomerCategoryRequest>
    {
        public CreateCustomerCategoryRequestValidator()
        {

            RuleFor(c => c.Name)
               .NotEmpty()
               .WithMessage("Name cannot be empty.")
               .MaximumLength(150)
               .MinimumLength(1)
               .WithMessage("Character length must be between 1 and 150.");
        }
    }
}
