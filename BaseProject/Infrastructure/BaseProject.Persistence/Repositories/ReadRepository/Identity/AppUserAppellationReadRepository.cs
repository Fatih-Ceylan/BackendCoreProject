using BaseProject.Application.Repositories.ReadRepository.Identity;
using BaseProject.Domain.Entities.Identity;
using BaseProject.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace BaseProject.Persistence.Repositories.ReadRepository.Identity
{
    public class AppUserAppellationReadRepository : ReadRepository<BaseProjectDbContext, AppUserAppellation>, IAppUserAppellationReadRepository
    {
        public AppUserAppellationReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
