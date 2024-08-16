using BaseProject.Domain.Entities.GCrm.Definitions.OpportunityManagement.Opportunity;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    public  class OpportunityWriteRepository : WriteRepository<BaseProjectDbContext, Opportunity>, IOpportunityWriteRepository
    {
        public OpportunityWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
