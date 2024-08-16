using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.OpportunityManagement.Opportunity
{
    public class SolutionOffer : BaseEntity
    {
        public string  Name { get; set; }
        public Opportunity  Opportunity { get; set; }
    }
}
