using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.Users.GetAll
{
    public class GetAllUsersRequest :Pagination, IRequest<GetAllUsersResponse>
    {
    }
}
