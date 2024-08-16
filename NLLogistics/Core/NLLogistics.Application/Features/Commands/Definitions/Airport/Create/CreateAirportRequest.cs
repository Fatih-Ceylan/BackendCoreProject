using MediatR;

namespace NLLogistics.Application.Features.Commands.Definitions.Airport.Create
{
    public class CreateAirportRequest: IRequest<CreateAirportResponse>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public int? CountryId { get; set; }

    }
}