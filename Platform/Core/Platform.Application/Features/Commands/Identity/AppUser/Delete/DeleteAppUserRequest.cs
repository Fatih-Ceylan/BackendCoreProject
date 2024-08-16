using MediatR;

namespace Platform.Application.Features.Commands.Identity.AppUser.Delete
{
    public class DeleteAppUserRequest : IRequest<DeleteAppUserResponse>
    {
        public string Id { get; set; }
    }
}