using MediatR;

namespace BaseProject.Application.Features.Commands.Identity.AppUser.Delete
{
    public class DeleteAppUserRequest : IRequest<DeleteAppUserResponse>
    {
        public string Id { get; set; }
    }
}