using Card.Application.VMs;

namespace Card.Application.Features.Queries.Definitions.OrderDetail.GetListByOrderId
{
    public class GetListByOrderIdResponse
    {
        public List<OrderDetailVM> OrderDetails { get; set; }
        public string Message { get; set; }
    }
}
