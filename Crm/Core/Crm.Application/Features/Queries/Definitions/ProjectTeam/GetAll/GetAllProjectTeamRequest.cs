using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.ProjectTeam.GetAll
{
    public  class GetAllProjectTeamRequest :Pagination, IRequest<GetAllProjectTeamResponse>
    {
    }
}
