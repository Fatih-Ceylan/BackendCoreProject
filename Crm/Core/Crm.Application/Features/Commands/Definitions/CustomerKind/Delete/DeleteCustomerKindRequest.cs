using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerKind.Delete
{
    public class DeleteCustomerKindRequest : IRequest<DeleteCustomerKindResponse>
    {
        public string Id { get; set; }
    }
}
