using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.Customer.Delete
{
    public class DeleteCustomerRequest : IRequest<DeleteCustomerResponse>
    {
        public string Id { get; set; }
    }
}