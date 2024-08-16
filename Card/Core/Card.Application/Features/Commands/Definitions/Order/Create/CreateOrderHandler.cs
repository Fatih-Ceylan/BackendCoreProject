using AutoMapper;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Commands.Definitions.Order.Create
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
    {
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly IMapper _mapper;

        public CreateOrderHandler(IOrderWriteRepository orderWriteRepository, IMapper mapper)
        {
            _orderWriteRepository = orderWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            T.Order order = _mapper.Map<T.Order>(request);

            await _orderWriteRepository.AddAsync(order);
            await _orderWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateOrderResponse>(order);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();
            //createdResponse.StaffId = order.StaffId.ToString();

            return createdResponse;
        }
    }
}
