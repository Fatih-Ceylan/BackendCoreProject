namespace Card.Application.Features.Queries.Definitions.StaffContact.GetQrCode
{
    public class GetQrCodeResponse
    { 
        public string QrCodeBase64 { get; set; }
        public string Url { get; set; }
        public string Message { get; set; }
        public string? StatusCode { get; set; }
    }
}
