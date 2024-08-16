using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProjectType.Create
{
    public  class CreateProjectTypeRequest :IRequest<CreateProjectTypeResponse>
    {
        public string Name { get; set; }
    }
}
