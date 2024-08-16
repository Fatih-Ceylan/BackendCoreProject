using FluentValidation;
using GCrm.Application.Features.Commands.Definitions.CustomerCategory.Update;

namespace GCrm.Application.Validators.CustomerCategory
{
    public class UpdateCustomerCategoryRequestValidator : AbstractValidator<UpdateCustomerCategoryRequest>
    {
        public UpdateCustomerCategoryRequestValidator()
        {
            //RuleFor(c => c.Name)
            //  .NotEmpty()
            //  .WithMessage("Name cannot be empty.")
            //  .MaximumLength(150)
            //  .MinimumLength(1)
            //  .WithMessage("Character length must be between 1 and 150.");
        }
    }
}
