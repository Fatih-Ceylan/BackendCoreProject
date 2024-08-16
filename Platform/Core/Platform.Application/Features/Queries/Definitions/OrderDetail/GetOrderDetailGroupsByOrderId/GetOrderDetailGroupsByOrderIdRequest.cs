using MediatR;

namespace Platform.Application.Features.Queries.Definitions.OrderDetail.GetOrderDetailGroupsByOrderId
{
    public class GetOrderDetailGroupsByOrderIdRequest : IRequest<GetOrderDetailGroupsByOrderIdResponse>
    {
        public string OrderId { get; set; }

    }
}