using O = Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.Abstractions.Services.Order
{
    public interface IOrderService
    {
        Task<bool> UpdateOrderStatus(string orderId, O.OrderStatus status);
        Task<bool> UpdateCargoTrackingNo(string orderId,string cargoTrackingNo);
    }
}