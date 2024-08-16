using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.OpportunityReference.GetAll
{
    public  class GetAllOpportunityReferenceResponse
    {
        public int TotalCount { get; set; }

        public List<OpportunityReferenceVM>  OpportunityReferences { get; set; }
    }
}
