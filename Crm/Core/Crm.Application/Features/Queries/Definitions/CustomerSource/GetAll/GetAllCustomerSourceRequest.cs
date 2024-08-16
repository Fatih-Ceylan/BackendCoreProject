using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.CustomerSource.GetAll
{
    public class GetAllCustomerSourceRequest : Pagination, IRequest<GetAllCustomerSourceResponse>
    {
    }
}
