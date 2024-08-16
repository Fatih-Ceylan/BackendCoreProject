using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.CustomerKind.GetAll
{
    public class GetAllCustomerKindRequest : Pagination, IRequest<GetAllCustomerKindResponse>
    {
    }
}
