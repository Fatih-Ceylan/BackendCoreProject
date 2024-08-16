using Platform.Application.Repositories.WriteRepository.Definitions;
using Platform.Domain.Entities.Definitions;
using Platform.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Platform.Persistence.Repositories.WriteRepository.Definitions
{
    public class CompanyWriteRepository : WriteRepository<PlatformDbContext, Company>, ICompanyWriteRepository
    {
        public CompanyWriteRepository(PlatformDbContext context) : base(context)
        {
        }
    }
}
