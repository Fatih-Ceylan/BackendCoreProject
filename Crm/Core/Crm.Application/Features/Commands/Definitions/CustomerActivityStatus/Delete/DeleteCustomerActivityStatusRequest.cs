using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityStatus.Delete
{
    public class DeleteCustomerActivityStatusRequest : IRequest<DeleteCustomerActivityStatusResponse>
    {
        public string Id { get; set; }
    }
}
