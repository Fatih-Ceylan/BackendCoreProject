using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProjectType.Update
{
    public  class UpdateProjectTypeRequest : IRequest<UpdateProjectTypeResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
