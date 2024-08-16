using FluentValidation;
using GControl.Application.Features.Commands.Definitions.Department.Update;

namespace GControl.Application.Validators.Department
{
    public class UpdateDepartmentRequestValidator : AbstractValidator<UpdateDepartmentRequest>
    {
        public UpdateDepartmentRequestValidator()
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
