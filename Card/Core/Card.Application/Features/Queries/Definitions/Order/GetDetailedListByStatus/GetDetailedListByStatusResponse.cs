using Card.Application.VMs;

namespace Card.Application.Features.Queries.Definitions.Order.GetDetailedListByStatus
{
    public class GetDetailedListByStatusResponse 
    {
        public List<DetailedOrderListVM> DetailedOrders { get; set; }
    }
}
