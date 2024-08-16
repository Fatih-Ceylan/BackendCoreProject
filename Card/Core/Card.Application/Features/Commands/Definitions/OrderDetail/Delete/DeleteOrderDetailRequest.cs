using MediatR;

namespace Card.Application.Features.Commands.Definitions.OrderDetail.Delete
{
    public class DeleteOrderDetailRequest : IRequest<DeleteOrderDetailResponse>
    {
        public string Id { get; set; }
    }
}
