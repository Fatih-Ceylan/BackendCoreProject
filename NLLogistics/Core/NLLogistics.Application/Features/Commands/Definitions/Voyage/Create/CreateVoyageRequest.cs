using MediatR;

namespace NLLogistics.Application.Features.Commands.Definitions.Voyage.Create
{
    public class CreateVoyageRequest: IRequest<CreateVoyageResponse>
    {
        public string VesselId { get; set; }

        public string Name { get; set; }

        public int? CountryId { get; set; }

    }
}