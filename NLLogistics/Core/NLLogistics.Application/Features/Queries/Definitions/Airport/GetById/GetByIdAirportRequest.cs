using MediatR;

namespace NLLogistics.Application.Features.Queries.Definitions.Airport.GetById
{
    public class GetByIdAirportRequest: IRequest<GetByIdAirportResponse>
    {
        public string Id { get; set; }

    }
}
