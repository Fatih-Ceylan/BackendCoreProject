using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityType.Create
{
    public class CreateCustomerActivityTypeRequest : IRequest<CreateCustomerActivityTypeResponse>
    {
        public string Name { get; set; }
    }
}
