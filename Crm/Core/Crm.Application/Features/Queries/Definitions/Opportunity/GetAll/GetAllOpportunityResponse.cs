using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.Opportunity.GetAll
{
    public  class GetAllOpportunityResponse
    {
        public int TotalCount { get; set; }

        public List<OpportunityVM>  Opportunities { get; set; }
    }
}
