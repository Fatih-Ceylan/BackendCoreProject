using AutoMapper;
using Platform.Application.Abstractions.Services.Definitions;
using Platform.Application.DTOs.Definitions.Order;
using Platform.Application.Repositories.WriteRepository.Definitions;
using Platform.Domain.Entities.Definitions;
using Utilities.Core.UtilityApplication.Enums;

namespace Platform.Persistence.Services.Definitions
{
    public class OrderService : IOrderService
    {
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly IMapper _mapper;

        public OrderService(IOrderWriteRepository orderWriteRepository, IMapper mapper)
        {
            _orderWriteRepository = orderWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateOrderResponseDTO> Create(CreateOrderRequestDTO request)
        {
            var order = _mapper.Map<Order>(request);

            order = await _orderWriteRepository.AddAsync(order);
            await _orderWriteRepository.SaveAsync();

            var response = _mapper.Map<CreateOrderResponseDTO>(order);
            response.Message = CommandResponseMessage.AddedSuccess.ToString();

            return response;
        }
    }
}