using Card.Application.Features.Commands.Definitions.Payment.VPos;

namespace Card.Application.Abstractions.Services.Payment
{
    public interface IVakifBankVposService
    {
        Task<CreatePaymentResponse> VerifyGateway(CreatePaymentRequest request);

    }
}
