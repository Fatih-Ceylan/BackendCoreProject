using BaseProject.Domain.Entities.GCrm.Definitions.OpportunityManagement.Opportunity;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    internal class OpportunitySectorWriteRepository : WriteRepository<BaseProjectDbContext, OpportunitySector>, IOpportunitySectorWriteRepository
    {
        public OpportunitySectorWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
