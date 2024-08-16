using BaseProject.Domain.Entities.GCrm.Definitions.OpportunityManagement.Opportunity;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    public  class OpportunityReferenceWriteRepository : WriteRepository<BaseProjectDbContext, OpportunityReference>, IOpportunityReferenceWriteRepository
    {
        public OpportunityReferenceWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
