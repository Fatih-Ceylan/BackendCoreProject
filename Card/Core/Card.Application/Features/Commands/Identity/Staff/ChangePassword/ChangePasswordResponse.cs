using Card.Application.VMs;

namespace Card.Application.Features.Commands.Identity.Staff.ChangePassword
{
    public class ChangePasswordResponse
    {
        public StaffVM Staff { get; set; }
        public string Message { get; set; }
        public string? StatusCode { get; set; }
    }
}
