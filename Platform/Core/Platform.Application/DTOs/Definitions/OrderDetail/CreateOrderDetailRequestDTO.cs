using Platform.Application.VMs.Definitions.OrderDetail;

namespace Platform.Application.DTOs.Definitions.OrderDetail
{
    public class CreateOrderDetailRequestDTO
    {
        public List<OrderDetailCreateVM> OrderDetails { get; set; }

    }
}