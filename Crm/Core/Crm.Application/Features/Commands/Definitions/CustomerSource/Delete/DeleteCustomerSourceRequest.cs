using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerSource.Delete
{
    public class DeleteCustomerSourceRequest : IRequest<DeleteCustomerSourceResponse>
    {
        public string Id { get; set; }
    }
}
