using Card.Application.VMs;

namespace Card.Application.Features.Queries.Definitions.Order.GetDetailedListById
{
    public class GetDetailedListByIdResponse
    {
        public List<DetailedOrderListVM> DetailedOrders { get; set; }
    }
}
