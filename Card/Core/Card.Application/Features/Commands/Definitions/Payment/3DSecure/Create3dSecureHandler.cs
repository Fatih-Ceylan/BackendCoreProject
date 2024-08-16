using Card.Application.Abstractions.Services.Payment;
using MediatR;

namespace Card.Application.Features.Commands.Definitions.Payment._3DSecure
{
    public class Create3dSecureHandler : IRequestHandler<Create3dSecureRequest, Create3dSecureResponse>
    {
        readonly IVakifBank3dSecureService _bankService;

        public Create3dSecureHandler(IVakifBank3dSecureService bankService)
        {
            _bankService = bankService;
        }

        public Task<Create3dSecureResponse> Handle(Create3dSecureRequest request, CancellationToken cancellationToken)
        {
            var response = _bankService.ThreeDGatewayRequest(request);
            return response;
        }
    }
}
