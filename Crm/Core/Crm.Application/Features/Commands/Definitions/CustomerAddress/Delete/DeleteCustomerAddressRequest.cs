using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerAddress.Delete
{
    public class DeleteCustomerAddressRequest : IRequest<DeleteCustomerAddressResponse>
    {
        public string Id { get; set; }
    }
}
