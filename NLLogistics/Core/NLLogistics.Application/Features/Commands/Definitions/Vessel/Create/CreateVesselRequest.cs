using MediatR;

namespace NLLogistics.Application.Features.Commands.Definitions.Vessel.Create
{
    public class CreateVesselRequest: IRequest<CreateVesselResponse>
    {
        public string Name { get; set; }

        public int CountryId { get; set; }

        public string Year { get; set; }

        public string Imo { get; set; }

        public string Link { get; set; }

    }
}