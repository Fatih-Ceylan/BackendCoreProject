using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProjectStatues.Update
{
    public  class UpdateProjectStatuesRequest :IRequest<UpdateProjectStatuesResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
