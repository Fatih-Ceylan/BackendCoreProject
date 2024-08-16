using FluentValidation;
using Card.Application.Features.Commands.Definitions.OrderDetail.Create;
using Card.Application.Validators.Order;

namespace Card.Application.Validators.OrderDetail
{
    public class CreateOrderDetailRequestValidator : AbstractValidator<CreateOrderDetailRequest>
    {
        public CreateOrderDetailRequestValidator()
        {
            RuleForEach(x => x.OrderDetails)
                .SetValidator(new CreateOrderDetailVMValidator());

            RuleFor(x => x.Order)
                .SetValidator(new CreateOrderVMRequestValidator());
        }
    }
}
