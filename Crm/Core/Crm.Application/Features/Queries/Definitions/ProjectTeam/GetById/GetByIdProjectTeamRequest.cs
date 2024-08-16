using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProjectTeam.GetById
{
    public  class GetByIdProjectTeamRequest : IRequest<GetByIdProjectTeamResponse>

    {
        public string Id { get; set; }
    }
}
