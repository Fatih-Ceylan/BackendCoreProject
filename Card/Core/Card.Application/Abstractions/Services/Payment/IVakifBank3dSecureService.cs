using Card.Application.Features.Commands.Definitions.Payment._3DSecure;

namespace Card.Application.Abstractions.Services.Payment
{
    public interface IVakifBank3dSecureService
    {
        Task<Create3dSecureResponse> ThreeDGatewayRequest(Create3dSecureRequest request);
    }
}
