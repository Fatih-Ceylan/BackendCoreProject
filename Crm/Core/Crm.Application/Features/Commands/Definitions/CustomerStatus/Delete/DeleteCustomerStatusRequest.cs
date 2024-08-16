using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerStatus.Delete
{
    public class DeleteCustomerStatusRequest : IRequest<DeleteCustomerStatusResponse>
    {
        public string Id { get; set; }
    }
}
