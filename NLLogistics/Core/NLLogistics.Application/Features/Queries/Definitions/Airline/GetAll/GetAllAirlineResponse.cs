using NLLogistics.Application.VMs.Definitions.Airline;

namespace NLLogistics.Application.Features.Queries.Definitions.Airline.GetAll
{
    public class GetAllAirlineResponse
    {
        public int TotalCount { get; set; }

        public List<AirlineVM> Airlines { get; set; }
    }
}
