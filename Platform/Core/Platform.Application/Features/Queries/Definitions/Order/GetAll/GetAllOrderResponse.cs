using Platform.Application.VMs.Definitions.Order;

namespace Platform.Application.Features.Queries.Definitions.Order.GetAll
{
    public class GetAllOrderResponse
    {
        public int TotalCount { get; set; }

        public List<OrderVM> Orders { get; set; }
    }
}