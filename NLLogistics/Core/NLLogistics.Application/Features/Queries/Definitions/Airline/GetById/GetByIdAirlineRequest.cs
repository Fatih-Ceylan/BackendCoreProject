using MediatR;

namespace NLLogistics.Application.Features.Queries.Definitions.Airline.GetById
{
    public class GetByIdAirportRequest: IRequest<GetByIdAirlineResponse>
    {
        public string Id { get; set; }

    }
}
