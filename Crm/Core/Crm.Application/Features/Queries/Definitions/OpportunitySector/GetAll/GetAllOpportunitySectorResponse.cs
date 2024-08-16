using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.OpportunitySector.GetAll
{
    public  class GetAllOpportunitySectorResponse
    {
        public int TotalCount { get; set; }

        public List<OpportunitySectorVM>  OpportunitySectors { get; set; }
    }
}
