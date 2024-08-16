using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityKind.Delete
{
    public class DeleteCustomerActivityKindRequest : IRequest<DeleteCustomerActivityKindResponse>
    {
        public string Id { get; set; }
    }
}
