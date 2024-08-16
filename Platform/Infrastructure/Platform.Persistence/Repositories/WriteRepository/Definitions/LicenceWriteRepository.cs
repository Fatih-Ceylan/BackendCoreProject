using Platform.Application.Repositories.WriteRepository.Definitions;
using Platform.Domain.Entities.Definitions;
using Platform.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Platform.Persistence.Repositories.WriteRepository.Definitions
{
    public class LicenseWriteRepository : WriteRepository<PlatformDbContext, License>, ILicenseWriteRepository
    {
        public LicenseWriteRepository(PlatformDbContext context) : base(context)
        {
        }
    }
}