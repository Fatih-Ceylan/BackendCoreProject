using BaseProject.Domain.Entities.GCrm.Definitions.OpportunityManagement.Opportunity;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    public  class OpportunitySectorReadRepository : ReadRepository<BaseProjectDbContext, OpportunitySector>, IOpportunitySectorReadRepository
    {
        public OpportunitySectorReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
