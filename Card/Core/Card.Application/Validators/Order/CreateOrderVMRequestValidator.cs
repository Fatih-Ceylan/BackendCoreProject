using FluentValidation;
using Card.Application.VMs;

namespace Card.Application.Validators.Order
{
    public class CreateOrderVMRequestValidator : AbstractValidator<CreateOrderVM>
    {
        public CreateOrderVMRequestValidator()
        { 
        }
    }
}
