using MediatR;

namespace Card.Application.Features.Commands.Definitions.Order.Delete
{
    public class DeleteOrderRequest : IRequest<DeleteOrderResponse>
    {
        public string Id { get; set; }
    }
}
