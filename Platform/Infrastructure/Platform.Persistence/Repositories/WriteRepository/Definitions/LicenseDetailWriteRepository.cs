using Platform.Application.Repositories.WriteRepository.Definitions;
using Platform.Domain.Entities.Definitions;
using Platform.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Platform.Persistence.Repositories.WriteRepository.Definitions
{
    public class LicenseDetailWriteRepository : WriteRepository<PlatformDbContext, LicenseDetail>, ILicenseDetailWriteRepository
    {
        public LicenseDetailWriteRepository(PlatformDbContext context) : base(context)
        {
        }
    }
}