using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProjectManager.Create
{
    public  class CreateProjectManagerRequest : IRequest<CreateProjectManagerResponse>
    {
        public string ProjectManagerName { get; set; }
    }
}
