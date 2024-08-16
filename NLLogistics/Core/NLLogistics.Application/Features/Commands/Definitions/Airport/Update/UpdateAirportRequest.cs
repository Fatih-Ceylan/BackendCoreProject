using MediatR;

namespace NLLogistics.Application.Features.Commands.Definitions.Airport.Update
{
    public class UpdateAirportRequest: IRequest<UpdateAirportResponse>
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int? CountryId { get; set; }
    }
}
