using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.CustomerAddress.GetAll
{
    public class GetAllCustomerAddressRequest : Pagination, IRequest<GetAllCustomerAddressResponse>
    {
    }
}