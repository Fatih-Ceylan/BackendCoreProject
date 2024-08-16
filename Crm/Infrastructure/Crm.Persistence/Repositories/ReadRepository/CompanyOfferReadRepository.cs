using BaseProject.Domain.Entities.GCrm.Definitions.OpportunityManagement.Opportunity;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    public  class CompanyOfferReadRepository : ReadRepository<BaseProjectDbContext, CompanyOffer>, ICompanyOfferReadRepository
    {
        public CompanyOfferReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
