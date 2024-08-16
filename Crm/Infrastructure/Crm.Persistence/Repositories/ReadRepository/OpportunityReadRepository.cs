using BaseProject.Domain.Entities.GCrm.Definitions.OpportunityManagement.Opportunity;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    public  class OpportunityReadRepository : ReadRepository<BaseProjectDbContext, Opportunity>, IOpportunityReadRepository
    {
        public OpportunityReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
