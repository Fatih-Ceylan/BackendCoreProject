using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.Project.Delete
{
    public  class DeleteProjectRequest : IRequest<DeleteProjectResponse>
    {
        public string  Id { get; set; }
    }
}
