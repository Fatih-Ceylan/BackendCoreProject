using BaseProject.Application.Repositories.WriteRepository.Identity;
using BaseProject.Domain.Entities.Identity;
using BaseProject.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace BaseProject.Persistence.Repositories.WriteRepository.Identity
{
    public class AppUserAppellationWriteRepository : WriteRepository<BaseProjectDbContext, AppUserAppellation>, IAppUserAppellationWriteRepository
    {
        public AppUserAppellationWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
