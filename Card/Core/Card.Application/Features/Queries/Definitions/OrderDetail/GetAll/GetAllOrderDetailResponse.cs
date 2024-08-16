using Card.Application.VMs;

namespace Card.Application.Features.Queries.Definitions.OrderDetail.GetAll
{
    public class GetAllOrderDetailResponse
    {
        public int TotalCount { get; set; }

        public List<OrderDetailVM> OrderDetails { get; set; }
    }
}
