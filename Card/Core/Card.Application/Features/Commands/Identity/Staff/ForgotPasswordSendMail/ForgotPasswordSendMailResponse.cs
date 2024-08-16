namespace Card.Application.Features.Commands.Identity.Staff.ForgotPasswordSendMail
{
    public class ForgotPasswordSendMailResponse
    {
        public string VerificationCode { get; set; }
        public string Message { get; set; }
        public string? StatusCode { get; set; }
    }
}
