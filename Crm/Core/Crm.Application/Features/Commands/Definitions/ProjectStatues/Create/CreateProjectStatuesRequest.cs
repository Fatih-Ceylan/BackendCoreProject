using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProjectStatues.Create
{
    public  class CreateProjectStatuesRequest :IRequest<CreateProjectStatuesResponse>
    {
        public string Name { get; set; }
    }
}
