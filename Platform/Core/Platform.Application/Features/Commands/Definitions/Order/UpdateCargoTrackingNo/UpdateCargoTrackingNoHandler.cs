using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.Repositories.WriteRepository.Definitions;

namespace Platform.Application.Features.Commands.Definitions.Order.UpdateCargoTrackingNo
{
    public class UpdateCargoTrackingNoHandler : IRequestHandler<UpdateCargoTrackingNoRequest, UpdateCargoTrackingNoResponse>
    {
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly IOrderReadRepository _orderReadRepository;
        public UpdateCargoTrackingNoHandler(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        public async Task<UpdateCargoTrackingNoResponse> Handle(UpdateCargoTrackingNoRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderReadRepository.GetByIdAsync(request.OrderId);
            order.CargoTrackingNo = request.CargoTrackingNo;

            await _orderWriteRepository.SaveAsync();

            UpdateCargoTrackingNoResponse response = new();
            response.OrderId = order.Id.ToString();
            response.CargoTrackingNo = order.CargoTrackingNo;
            response.MessageList = new();
            response.MessageList.Add("Updated order status for the platform.");
            
            return response;
        }
    }
}