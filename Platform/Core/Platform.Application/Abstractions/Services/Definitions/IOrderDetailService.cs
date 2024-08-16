using Platform.Application.DTOs.Definitions.OrderDetail;

namespace Platform.Application.Abstractions.Services.Definitions
{
    public interface IOrderDetailService
    {
        Task<CreateOrderDetailResponseDTO> Create(CreateOrderDetailRequestDTO request);
    }
}