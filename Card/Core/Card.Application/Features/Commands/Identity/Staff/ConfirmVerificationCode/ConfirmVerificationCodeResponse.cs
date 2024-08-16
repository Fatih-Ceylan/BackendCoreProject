namespace Card.Application.Features.Commands.Identity.Staff.ConfirmVerificationCode
{
    public class ConfirmVerificationCodeResponse
    {
        public string StaffId { get; set; }
        public string Message { get; set; }
        public string StatusCode { get; set; }
        public string VerificationCode { get; set; }
    }
}
