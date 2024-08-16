using MediatR;

namespace Card.Application.Features.Queries.Definitions.OrderDetail.GetListByOrderId
{
    public class GetListByOrderIdRequest : IRequest<GetListByOrderIdResponse>
    {
        public string Id { get; set; }
    }
}
