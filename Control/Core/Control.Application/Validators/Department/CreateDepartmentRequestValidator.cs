using FluentValidation;
using GControl.Application.Features.Commands.Definitions.Department.Create;

namespace GControl.Application.Validators.Department
{
    public class CreateDepartmentRequestValidator : AbstractValidator<CreateDepartmentRequest>
    {
        public CreateDepartmentRequestValidator()
        {
            RuleFor(c => c.BaseDepartmentId)
             .NotEmpty()
             .WithMessage("BaseDepartmentId cannot be empty.");

            RuleFor(c => c.LocationId)
             .NotEmpty()
             .WithMessage("LocationId cannot be empty.");
        }
    }
}
