using Platform.Application.Repositories.ReadRepository.Definitions.Files;
using Platform.Domain.Entities.Definitions.Files;
using Platform.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Platform.Persistence.Repositories.ReadRepository.Definitions.Files
{
    public class CompanyFileReadRepository : ReadRepository<PlatformDbContext, CompanyFile>, ICompanyFileReadRepository
    {
        public CompanyFileReadRepository(PlatformDbContext context) : base(context)
        {
        }
    }
}