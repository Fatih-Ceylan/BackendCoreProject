using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Domain.Entities.Definitions;
using Platform.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Platform.Persistence.Repositories.ReadRepository.Definitions
{
    public class LicenseTypeReadRepository : ReadRepository<PlatformDbContext, LicenseType>, ILicenseTypeReadRepository
    {
        public LicenseTypeReadRepository(PlatformDbContext context) : base(context)
        {
        }
    }
}
