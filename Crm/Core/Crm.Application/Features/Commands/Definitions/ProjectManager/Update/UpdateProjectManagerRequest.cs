using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProjectManager.Update
{
    public  class UpdateProjectManagerRequest : IRequest<UpdateProjectManagerResponse>
    {
        public string  Id { get; set; }
        public string ProjectManagerName { get; set; }
    }
}
