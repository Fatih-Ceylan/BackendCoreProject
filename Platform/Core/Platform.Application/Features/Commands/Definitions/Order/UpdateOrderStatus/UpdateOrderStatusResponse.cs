
namespace Platform.Application.Features.Commands.Definitions.Order.UpdateOrderStatus
{
    public class UpdateOrderStatusResponse
    {
        public string OrderId { get; set; }

        public string OrderIdFromModule { get; set; }

        public string OrderStatus { get; set; }

        public List<string> MessageList { get; set; }
    }
}