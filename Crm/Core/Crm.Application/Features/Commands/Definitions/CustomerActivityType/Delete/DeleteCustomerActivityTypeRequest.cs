using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityType.Delete
{
    public class DeleteCustomerActivityTypeRequest : IRequest<DeleteCustomerActivityTypeResponse>
    {
        public string Id { get; set; }
    }
}
