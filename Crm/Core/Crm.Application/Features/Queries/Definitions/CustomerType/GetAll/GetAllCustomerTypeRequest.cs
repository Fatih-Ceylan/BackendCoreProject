using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.CustomerType.GetAll
{
    public class GetAllCustomerTypeRequest : Pagination, IRequest<GetAllCustomerTypeResponse>
    {
    }
}
