using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerRepresentative.Delete
{
    public class DeleteCustomerRepresentativeRequest : IRequest<DeleteCustomerRepresentativeResponse>
    {
        public string Id { get; set; }
    }
}
