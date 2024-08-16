using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProjectTeam.Delete
{
    public  class DeleteProjectTeamRequest : IRequest<DeleteProjectTeamResponse>
    {
        public string  Id { get; set; }
    }
}
