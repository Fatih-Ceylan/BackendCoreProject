using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace NLLogistics.Application.Features.Queries.Definitions.Airline.GetAll
{
    public class GetAllAirlineRequest: Pagination, IRequest<GetAllAirlineResponse>
    {

    }
}