using Platform.Application.DTOs.Definitions.Order;

namespace Platform.Application.Abstractions.Services.Definitions
{
    public interface IOrderService
    {
        Task<CreateOrderResponseDTO> Create(CreateOrderRequestDTO request);
    }
}
