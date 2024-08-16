using BaseProject.Application.Repositories.ReadRepository.Identity;
using BaseProject.Domain.Entities.Identity.File;
using BaseProject.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace BaseProject.Persistence.Repositories.ReadRepository.Identity
{
    public class AppUserFileReadRepository : ReadRepository<BaseProjectDbContext, AppUserFile>, IAppUserFileReadRepository
    {
        public AppUserFileReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
