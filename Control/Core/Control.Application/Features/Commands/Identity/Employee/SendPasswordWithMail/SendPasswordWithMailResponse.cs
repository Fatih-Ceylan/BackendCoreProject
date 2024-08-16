namespace GControl.Application.Features.Commands.Identity.Employee.SendPasswordWithMail
{
    public class SendPasswordWithMailResponse
    {
        public string VerificationCode { get; set; }
        public string Message { get; set; }
        public string? StatusCode { get; set; }

    }
}
