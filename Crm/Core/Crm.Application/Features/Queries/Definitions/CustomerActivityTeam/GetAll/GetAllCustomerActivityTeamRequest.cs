using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivityTeam.GetAll
{
    public  class GetAllCustomerActivityTeamRequest :Pagination, IRequest<GetAllCustomerActivityTeamResponse>
    {
    }
}
