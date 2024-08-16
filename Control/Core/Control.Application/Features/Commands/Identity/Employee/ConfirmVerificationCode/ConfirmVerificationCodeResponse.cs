namespace GControl.Application.Features.Commands.Identity.Employee.ConfirmVerificationCode
{
    public class ConfirmVerificationCodeResponse
    {
        public string EmployeeId { get; set; }
        public string Message { get; set; }
        public string StatusCode { get; set; }
        public string VerificationCode { get; set; }

    }
}
