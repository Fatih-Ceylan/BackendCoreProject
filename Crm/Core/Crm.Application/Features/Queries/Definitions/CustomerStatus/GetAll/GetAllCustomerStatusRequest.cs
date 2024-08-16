using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.CustomerStatus.GetAll
{
    public class GetAllCustomerStatusRequest : Pagination, IRequest<GetAllCustomerStatusResponse>
    {
    }
}
