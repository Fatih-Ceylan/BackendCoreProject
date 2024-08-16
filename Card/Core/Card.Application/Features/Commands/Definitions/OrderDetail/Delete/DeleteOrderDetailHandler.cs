using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.Features.Commands.Definitions.OrderDetail.Delete
{
    public class DeleteOrderDetailHandler : IRequestHandler<DeleteOrderDetailRequest, DeleteOrderDetailResponse>
    {
        readonly IOrderDetailWriteRepository _orderDetailWriteRepository;

        public DeleteOrderDetailHandler(IOrderDetailWriteRepository orderDetailWriteRepository)
        {
            _orderDetailWriteRepository = orderDetailWriteRepository;
        }

        public async Task<DeleteOrderDetailResponse> Handle(DeleteOrderDetailRequest request, CancellationToken cancellationToken)
        {
            await _orderDetailWriteRepository.SoftDeleteAsync(request.Id);
            await _orderDetailWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString()
            };
        }
    }
}
