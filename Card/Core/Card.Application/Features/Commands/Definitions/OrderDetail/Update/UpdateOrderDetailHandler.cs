using AutoMapper;
using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Commands.Definitions.OrderDetail.Update
{
    public class UpdateOrderDetailHandler : IRequestHandler<UpdateOrderDetailRequest, UpdateOrderDetailResponse>
    {
        readonly IOrderDetailWriteRepository _orderDetailWriteRepository;
        readonly IOrderDetailReadRepository _orderDetailReadRepository;
        readonly IMapper _mapper;

        public UpdateOrderDetailHandler(IOrderDetailWriteRepository orderDetailWriteRepository, IOrderDetailReadRepository orderDetailReadRepository, IMapper mapper)
        {
            _orderDetailWriteRepository = orderDetailWriteRepository;
            _orderDetailReadRepository = orderDetailReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdateOrderDetailResponse> Handle(UpdateOrderDetailRequest request, CancellationToken cancellationToken)
        {
            T.OrderDetail orderDetail = await _orderDetailReadRepository.GetByIdAsync(request.Id);
            orderDetail = _mapper.Map(request, orderDetail);
            await _orderDetailWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateOrderDetailResponse>(orderDetail);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
