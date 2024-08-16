using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProjectTeam.Create
{
    public  class CreateProjectTeamRequest :IRequest<CreateProjectTeamResponse>
    {
        public String ProjectTeamName { get; set; }
    }
}
