using BaseProject.Domain.Entities.GCrm.Definitions.OpportunityManagement.Opportunity;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    public  class OpportunityReferenceReadRepository : ReadRepository<BaseProjectDbContext, OpportunityReference>, IOpportunityReferenceReadRepository
    {
        public OpportunityReferenceReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
