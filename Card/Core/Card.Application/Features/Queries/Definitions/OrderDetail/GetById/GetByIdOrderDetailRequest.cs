using MediatR;

namespace Card.Application.Features.Queries.Definitions.OrderDetail.GetById
{
    public class GetByIdOrderDetailRequest : IRequest<GetByIdOrderDetailResponse>
    {
        public string Id { get; set; }
    }
}
