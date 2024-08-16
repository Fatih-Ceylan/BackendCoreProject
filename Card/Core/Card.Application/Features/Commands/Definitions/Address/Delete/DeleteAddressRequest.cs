using MediatR;

namespace Card.Application.Features.Commands.Definitions.Address.Delete
{
    public class DeleteAddressRequest : IRequest<DeleteAddressResponse>
    {
        public string Id { get; set; }
    }
}
