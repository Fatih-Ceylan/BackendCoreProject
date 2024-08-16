using BaseProject.Domain.Entities.GCrm.Definitions.OpportunityManagement.Opportunity;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    public  class CompanyOfferWriteRepository : WriteRepository<BaseProjectDbContext, CompanyOffer>, ICompanyOfferWriteRepository
    {
        public CompanyOfferWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

