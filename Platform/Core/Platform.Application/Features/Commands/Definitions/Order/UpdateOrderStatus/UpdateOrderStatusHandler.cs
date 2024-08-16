using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.Repositories.WriteRepository.Definitions;

namespace Platform.Application.Features.Commands.Definitions.Order.UpdateOrderStatus
{
    public class UpdateOrderStatusHandler : IRequestHandler<UpdateOrderStatusRequest, UpdateOrderStatusResponse>
    {
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly IOrderReadRepository _orderReadRepository;
        public UpdateOrderStatusHandler(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        public async Task<UpdateOrderStatusResponse> Handle(UpdateOrderStatusRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderReadRepository.GetByIdAsync(request.OrderId);
            order.Status = request.OrderStatus;

            await _orderWriteRepository.SaveAsync();

            UpdateOrderStatusResponse response = new();
            response.OrderId = order.Id.ToString();
            response.OrderStatus = order.Status.ToString();
            response.MessageList = new();
            response.MessageList.Add("Updated order status for the platform.");
            
            return response;
        }
    }
}