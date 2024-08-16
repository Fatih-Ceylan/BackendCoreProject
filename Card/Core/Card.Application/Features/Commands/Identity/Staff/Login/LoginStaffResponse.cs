namespace Card.Application.Features.Commands.Identity.Staff.Login
{
    public class LoginStaffResponse
    {
        public string Token { get; set; }
        public string StaffId { get; set; }
        public string Message { get; set; }
        public string? StatusCode { get; set; }
    }
}
