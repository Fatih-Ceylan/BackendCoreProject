namespace Card.Application.Features.Commands.Definitions.Payment._3DSecure
{
    public class Create3dSecureResponse
    {
        public string MessageId { get; set; }
        public string Version { get; set; }
        public string Status { get; set; }
        public string Pareq { get; set; }
        public string AcsUrl { get; set; }
        public string TermUrl { get; set; }
        public string MD { get; set; }
        public string ActualBrand { get; set; }
        public string ErrorCode { get; set; }
    }
}
