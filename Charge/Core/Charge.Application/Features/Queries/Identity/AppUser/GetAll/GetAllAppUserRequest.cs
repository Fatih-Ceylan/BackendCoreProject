using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCharge.Application.Features.Queries.Identity.AppUser.GetAll
{
    public class GetAllAppUserRequest : Pagination, IRequest<GetAllAppUserResponse>
    {
    }
}