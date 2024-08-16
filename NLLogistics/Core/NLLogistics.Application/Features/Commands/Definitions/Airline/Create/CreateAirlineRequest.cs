using MediatR;

namespace NLLogistics.Application.Features.Commands.Definitions.Airline.Create
{
    public class CreateAirlineRequest: IRequest<CreateAirlineResponse>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public int? CountryId { get; set; }
    }
}