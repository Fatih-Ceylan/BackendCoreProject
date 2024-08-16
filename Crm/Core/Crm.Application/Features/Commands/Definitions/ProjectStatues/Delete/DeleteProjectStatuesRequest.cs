using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProjectStatues.Delete
{
    public  class DeleteProjectStatuesRequest : IRequest<DeleteProjectStatuesResponse>
    {
        public string Id { get; set; }
    }
}
