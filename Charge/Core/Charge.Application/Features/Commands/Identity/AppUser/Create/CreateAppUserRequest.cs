using MediatR;

namespace GCharge.Application.Features.Commands.Identity.AppUser.Create
{
    public class CreateAppUserRequest : IRequest<CreateAppUserResponse>
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }

    }
}