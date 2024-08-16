using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProjectManager.Delete
{
    public  class DeleteProjectManagerRequest : IRequest<DeleteProjectManagerResponse>
    {
        public string  Id { get; set; }
    }
}
