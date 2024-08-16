using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivityKind.GetAll
{
    public  class GetAllCustomerActivityKindRequest : Pagination, IRequest<GetAllCustomerActivityKindResponse>
    {
    }
}
