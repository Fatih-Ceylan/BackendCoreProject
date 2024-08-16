using MediatR;

namespace Platform.Application.Features.Commands.Identity.AppUser.Update
{
    public class UpdateAppUserRequest : IRequest<UpdateAppUserResponse>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public bool IsDeleted { get; set; }

        public string? ProfileImagePath { get; set; }
    }
}