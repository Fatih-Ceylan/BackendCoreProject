using Platform.Application.Repositories.WriteRepository.Definitions;
using Platform.Domain.Entities.Definitions;
using Platform.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Platform.Persistence.Repositories.WriteRepository.Definitions
{
    public class GModuleWriteRepository : WriteRepository<PlatformDbContext, GModule>, IGModuleWriteRepository
    {
        public GModuleWriteRepository(PlatformDbContext context) : base(context)
        {
        }
    }
}
