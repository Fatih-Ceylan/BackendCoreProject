using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProjectTeam.Update
{
    public  class UpdateProjectTeamRequest : IRequest<UpdateProjectTeamResponse>
    {
        public string  Id { get; set; }
        public String ProjectTeamName { get; set; }
    }
}
