using MediatR;

namespace Card.Application.Features.Commands.Definitions.Cargo.Delete
{
    public class DeleteCargoRequest : IRequest<DeleteCargoResponse>
    {
        public string Id { get; set; }
    }
}
