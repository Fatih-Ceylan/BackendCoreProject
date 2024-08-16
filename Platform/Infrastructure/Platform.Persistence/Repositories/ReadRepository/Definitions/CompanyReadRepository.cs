using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Domain.Entities.Definitions;
using Platform.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Platform.Persistence.Repositories.ReadRepository.Definitions
{
    public class CompanyReadRepository : ReadRepository<PlatformDbContext, Company>, ICompanyReadRepository
    {
        public CompanyReadRepository(PlatformDbContext context) : base(context)
        {
        }
    }
}
