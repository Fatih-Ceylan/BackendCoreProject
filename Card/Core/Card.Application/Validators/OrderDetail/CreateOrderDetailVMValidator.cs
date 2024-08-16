using FluentValidation;
using Card.Application.VMs;

namespace Card.Application.Validators.OrderDetail
{
    public class CreateOrderDetailVMValidator : AbstractValidator<CreateOrderDetailVM>
    {
        public CreateOrderDetailVMValidator()
        {
            RuleFor(x => x.PurchasedForStaffId)
                .NotEmpty().WithMessage("PurchasedForStaffId is required.")
                .MaximumLength(36)
                .WithMessage("PurchasedForStaffId must not exceed 36 characters.")
                .Matches(@"^[{(]?[0-9a-fA-F]{8}(-?[0-9a-fA-F]{4}){3}-?[0-9a-fA-F]{12}[)}]?$")
                .WithMessage("PurchasedForStaffId must be a valid GUID.");
        }
    }
}
