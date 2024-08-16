using NLLogistics.Application.VMs.Definitions.Voyage;

namespace NLLogistics.Application.Features.Queries.Definitions.Voyage.GetAll
{
    public class GetAllVoyageResponse
    {
        public int TotalCount { get; set; }

        public List<VoyageVM> Voyages { get; set; }
    }
}
