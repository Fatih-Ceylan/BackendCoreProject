using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.OpportunityStage.GetAll
{
    public  class GetAllOpportunityStageResponse
    {
        public int TotalCount { get; set; }

        public List<OpportunityStageVM>   OpportunityStages { get; set; }
    }
}
