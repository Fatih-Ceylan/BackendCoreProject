using BaseProject.Domain.Entities.GCrm.Definitions.OpportunityManagement.Opportunity;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    public  class CompanyTenderWriteRepository : WriteRepository<BaseProjectDbContext, CompanyTender>, ICompanyTenderWriteRepository
    {
        public CompanyTenderWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
