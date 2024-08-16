using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.CustomerSector.GetAll
{
    public class GetAllCustomerSectorRequest : Pagination, IRequest<GetAllCustomerSectorResponse>
    {
    }
}