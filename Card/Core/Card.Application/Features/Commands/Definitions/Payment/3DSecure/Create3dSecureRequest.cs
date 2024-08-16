using MediatR;

namespace Card.Application.Features.Commands.Definitions.Payment._3DSecure
{
    public class Create3dSecureRequest : IRequest<Create3dSecureResponse>
    {
        public string MerchantId { get; set; }
        public string Password { get; set; }
        public string VerifyEnrollmentRequestId { get; set; }
        public string Pan { get; set; }
        public string ExpiryDate { get; set; }
        public decimal PurchaseAmount { get; set; }
        public int Currency { get; set; }
        public string BrandName { get; set; }
        public string SuccessUrl { get; set; }
        public string FailureUrl { get; set; }
        public int? InstallmentCount { get; set; }
        public string OrderNumber { get; set; }
    }
}
