using Platform.Application.VMs.Definitions.OrderDetail;

namespace Platform.Application.Features.Queries.Definitions.OrderDetail.GetOrderDetailGroupsByOrderId
{
    public class GetOrderDetailGroupsByOrderIdResponse
    {
        public int TotalCount { get; set; }
        
        public List<OrderDetailGroupVM> OrderDetailGroups { get; set; }
    }
}