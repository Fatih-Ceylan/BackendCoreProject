using MediatR;

namespace BaseProject.Application.Features.Commands.Identity.AppUser.Login
{
    public class LoginAppUserRequest : IRequest<LoginAppUserResponse>
    {
        public string UserNameOrEmail { get; set; }

        public string Password { get; set; }

        public string UrlPath { get; set; }

        public string MasterCompanyIdFromPlatform { get; set; }
    }
}