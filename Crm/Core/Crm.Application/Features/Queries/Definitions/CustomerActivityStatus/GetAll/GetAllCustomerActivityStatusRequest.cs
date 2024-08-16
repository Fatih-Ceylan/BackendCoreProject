using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivityStatus.GetAll
{
    public  class GetAllCustomerActivityStatusRequest : Pagination , IRequest<GetAllCustomerActivityStatusResponse>
    {

    }
}
