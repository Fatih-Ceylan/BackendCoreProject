namespace Card.Infrastructure.Dtos
{
    public class PaymentResponseDto
    {
        public string MerchantId { get; set; }
        public string TransactionType { get; set; }
        public string TransactionId { get; set; }
        public string OrderId { get; set; }
        public string ResultCode { get; set; }
        public string ResultDetail { get; set; }
        public string AuthCode { get; set; }
        public string HostDate { get; set; }
        public string Rrn { get; set; }
        public string CurrencyAmount { get; set; }
        public string CurrencyCode { get; set; }
        public string ThreeDSecureType { get; set; }
        public string GainedPoint { get; set; }
        public string TotalPoint { get; set; }
        public string BatchNo { get; set; }
        public string TLAmount { get; set; }
    }
}
