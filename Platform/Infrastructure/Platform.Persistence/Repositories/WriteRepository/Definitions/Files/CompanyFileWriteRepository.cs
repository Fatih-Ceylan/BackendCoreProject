using Platform.Application.Repositories.WriteRepository.Definitions.Files;
using Platform.Domain.Entities.Definitions.Files;
using Platform.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Platform.Persistence.Repositories.WriteRepository.Definitions.Files
{
    public class CompanyFileWriteRepository : WriteRepository<PlatformDbContext, CompanyFile>, ICompanyFileWriteRepository
    {
        public CompanyFileWriteRepository(PlatformDbContext context) : base(context)
        {
        }
    }
}