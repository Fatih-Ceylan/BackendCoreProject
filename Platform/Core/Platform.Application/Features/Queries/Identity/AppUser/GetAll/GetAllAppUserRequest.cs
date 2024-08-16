using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace Platform.Application.Features.Queries.Identity.AppUser.GetAll
{
    public class GetAllAppUserRequest : Pagination, IRequest<GetAllAppUserResponse>
    {
    }
}