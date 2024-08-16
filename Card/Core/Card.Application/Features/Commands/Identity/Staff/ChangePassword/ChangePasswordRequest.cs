using MediatR;

namespace Card.Application.Features.Commands.Identity.Staff.ChangePassword
{
    public class ChangePasswordRequest : IRequest<ChangePasswordResponse>
    {
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string StaffId { get; set; }
    }
}
