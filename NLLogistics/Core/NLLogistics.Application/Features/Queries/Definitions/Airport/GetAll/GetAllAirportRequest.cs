using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace NLLogistics.Application.Features.Queries.Definitions.Airport.GetAll
{
    public class GetAllAirportRequest: Pagination, IRequest<GetAllAirportResponse>
    {

    }
}