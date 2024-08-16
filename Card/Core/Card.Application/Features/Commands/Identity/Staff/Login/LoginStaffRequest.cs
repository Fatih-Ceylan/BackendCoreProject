using MediatR;

namespace Card.Application.Features.Commands.Identity.Staff.Login
{
    public class LoginStaffRequest : IRequest<LoginStaffResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; } 
    }
}
