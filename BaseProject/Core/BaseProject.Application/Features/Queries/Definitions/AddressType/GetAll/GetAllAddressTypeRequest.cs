using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace BaseProject.Application.Features.Queries.Definitions.AddressType.GetAll
{
    public class GetAllAddressTypeRequest : Pagination, IRequest<GetAllAddressTypeResponse>
    {

    }
}