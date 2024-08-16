using NLLogistics.Application.VMs.Definitions.Vessel;

namespace NLLogistics.Application.Features.Queries.Definitions.Vessel.GetAll
{
    public class GetAllVesselResponse
    {
        public int TotalCount { get; set; }

        public List<VesselVM> Vessels { get; set; }
    }
}
