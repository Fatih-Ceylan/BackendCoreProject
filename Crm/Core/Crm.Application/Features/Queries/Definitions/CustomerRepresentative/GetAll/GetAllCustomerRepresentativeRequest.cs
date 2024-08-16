using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.CustomerRepresentative.GetAll
{
    public  class GetAllCustomerRepresentativeRequest : Pagination, IRequest<GetAllCustomerRepresentativeResponse>
    {
    }
}
