using BaseProject.Domain.Entities.GCrm.Definitions.OpportunityManagement.Opportunity;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    public  class OpportunityStageWriteRepository : WriteRepository<BaseProjectDbContext, OpportunityStage>, IOpportunityStageWriteRepository
    {
        public OpportunityStageWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
