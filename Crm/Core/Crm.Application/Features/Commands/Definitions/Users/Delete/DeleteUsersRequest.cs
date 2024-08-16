using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.Users.Delete
{
    public  class DeleteUsersRequest : IRequest<DeleteUsersResponse>
    {
        public string Id { get; set; }
    }
}
