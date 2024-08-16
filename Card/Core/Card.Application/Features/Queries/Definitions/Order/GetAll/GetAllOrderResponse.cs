using Card.Application.VMs;

namespace Card.Application.Features.Queries.Definitions.Order.GetAll
{
    public class GetAllOrderResponse
    {
        public int TotalCount { get; set; }

        public List<OrderVM> Orders { get; set; }
    }
}
