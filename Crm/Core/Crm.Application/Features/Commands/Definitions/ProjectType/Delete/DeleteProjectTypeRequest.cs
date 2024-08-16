using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProjectType.Delete
{
    public  class DeleteProjectTypeRequest : IRequest<DeleteProjectTypeResponse>
    {
        public string Id { get; set; }
    }
}
