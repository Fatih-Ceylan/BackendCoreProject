using NLLogistics.Application.VMs.Definitions.Airport;

namespace NLLogistics.Application.Features.Queries.Definitions.Airport.GetAll
{
    public class GetAllAirportResponse
    {
        public int TotalCount { get; set; }

        public List<AirportVM> Airports { get; set; }
    }
}
