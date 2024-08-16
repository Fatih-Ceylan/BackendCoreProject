
using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.CustomerGroup.GetAll
{
    public  class GetAllCustomerGroupRequest : Pagination, IRequest<GetAllCustomerGroupResponse>
    {
    }
}
