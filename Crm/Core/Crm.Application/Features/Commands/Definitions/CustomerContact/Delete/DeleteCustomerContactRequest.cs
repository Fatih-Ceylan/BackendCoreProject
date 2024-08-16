using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerContact.Delete
{
    public class DeleteCustomerContactRequest : IRequest<DeleteCustomerContactResponse>
    {
        public string Id { get; set; }
    }
}
