using Card.Application.VMs;

namespace Card.Application.Features.Queries.Definitions.Order.GetDetailedListByDate
{
    public class GetDetailedListByDateResponse
    {
        public List<DetailedOrderListVM> DetailedOrders { get; set; }
    }
}
