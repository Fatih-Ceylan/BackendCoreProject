using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivityType.GetAll
{
    public  class GetAllCustomerActivityTypeRequest : Pagination , IRequest<GetAllCustomerActivityTypeResponse>
    {
    }
}
