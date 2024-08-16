using MediatR;

namespace Card.Application.Features.Commands.Definitions.Card.Delete
{
    public class DeleteCardRequest : IRequest<DeleteCardResponse>
    {
        public string Id { get; set; }
    }
}
