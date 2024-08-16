using MediatR;

namespace GControl.Application.Features.Commands.Identity.Employee.ChangePassword
{
    public class ChangePasswordRequest : IRequest<ChangePasswordResponse>
    {
        public string CurrentPassword { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string EmployeeId { get; set; }
    }
}
