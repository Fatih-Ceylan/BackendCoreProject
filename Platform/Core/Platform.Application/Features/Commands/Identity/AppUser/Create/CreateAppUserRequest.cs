using MediatR;

namespace Platform.Application.Features.Commands.Identity.AppUser.Create
{
    public class CreateAppUserRequest : IRequest<CreateAppUserResponse>
    {
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }

        public string? ProfileImagePath { get; set; }
    }
}
