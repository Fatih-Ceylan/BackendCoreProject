using MediatR;

namespace Platform.Application.Features.Commands.Identity.AppUser.Login
{
    public class LoginAppUserRequest : IRequest<LoginAppUserResponse>
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
