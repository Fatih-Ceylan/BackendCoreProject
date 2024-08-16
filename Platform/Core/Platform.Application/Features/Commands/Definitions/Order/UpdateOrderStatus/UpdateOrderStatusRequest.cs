using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace Platform.Application.Features.Commands.Definitions.Order.UpdateOrderStatus
{
    public class UpdateOrderStatusRequest : IRequest<UpdateOrderStatusResponse>
    {
        public string OrderId { get; set; }

        public string OrderIdFromModule { get; set; }

        public OrderStatus OrderStatus { get; set; }

    }
}