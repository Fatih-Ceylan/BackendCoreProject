using AutoMapper;
using Platform.Application.Abstractions.Services.Definitions;
using Platform.Application.DTOs.Definitions.OrderDetail;
using Platform.Application.Repositories.WriteRepository.Definitions;
using Platform.Domain.Entities.Definitions;

namespace Platform.Persistence.Services.Definitions
{
    //xxyy
    public class OrderDetailService: IOrderDetailService
    {
        readonly IOrderDetailWriteRepository _orderDetailWriteRepository;
        readonly IMapper _mapper;

        public OrderDetailService(IOrderDetailWriteRepository orderDetailWriteRepository, IMapper mapper)
        {
            _orderDetailWriteRepository = orderDetailWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateOrderDetailResponseDTO> Create(CreateOrderDetailRequestDTO request)
        {
            var orderDetail = _mapper.Map<List<OrderDetail>>(request.OrderDetails); 
            await _orderDetailWriteRepository.AddRangeAsync(orderDetail);
            await _orderDetailWriteRepository.SaveAsync();

            return new()
            {
                Message = "Order Details created success."
            };
        }
    }
}