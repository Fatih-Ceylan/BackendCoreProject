using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerSector.Delete
{
    public class DeleteCustomerSectorRequest : IRequest<DeleteCustomerSectorResponse>
    {
        public string Id { get; set; }
    }
}
